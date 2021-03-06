﻿using System;
using System.Collections.Generic;
using System.Linq;
using G2048.Models;
using G2048.Tools.Helpers;
using UnityEngine;

namespace G2048.Tools
{
    public class BoxTools
    {
        public BoxTools(int posMin, int posMax, Action<NumberStack> onDoubledBox)
        {
            this.PosMin = posMin;
            this.PosMax = posMax;

            this.OnDoubledBox = onDoubledBox;
        }

        public int PosMin
        {
            get;
            set;
        }

        public int PosMax
        {
            get;
            set;
        }

        public Action<NumberStack> OnDoubledBox
        {
            get;
            set;
        }

        public NumberBox[] MergeAsc(NumberBox[] boxes, Func<NumberBox, int> key, Func<NumberBox, int> getPos, Func<NumberBox, int, NumberBox> updatePos)
        {
            return
                boxes.GroupBy(key)
                     .Select(g => g.OrderBy(getPos)
                                   .Aggregate(new NumberStack[0], this.MergeBox)
                                   .Select((ns, i) => ns.ModifyBox(updatePos(ns.Box, this.PosMin + i))))
                     .SelectMany((nss) => NumberStack.MapBoxWithAction(nss, this.OnDoubledBox))
                     .ToArray();
        }

        public NumberStack[] MergeBox(NumberStack[] bs, NumberBox box)
        {
            if (bs.Any() && bs.Last().Box.N == box.N)
            {
                // 最後が同じなら倍プッシュ
                var numberStack = bs.Last().Double();

                return bs.Reverse().Skip(1).Reverse().Append(numberStack).ToArray();
            }
            else
            {
                // それ以外なら単純に追加
                return bs.Append(new NumberStack(box)).ToArray();
            }
        }

        public NumberBox[] MergeDesc(NumberBox[] boxes, Func<NumberBox, int> key, Func<NumberBox, int> getPos, Func<NumberBox, int, NumberBox> updatePos)
        {
            //Func<NumberStack>
            return
                boxes.GroupBy(key)
                     .Select(g => g.OrderByDescending(getPos)
                                   .Aggregate(new NumberStack[0], this.MergeBox)
                                   .Select((ns, i) => ns.ModifyBox(updatePos(ns.Box, this.PosMax - i))))
                     .SelectMany((nss) => NumberStack.MapBoxWithAction(nss, this.OnDoubledBox))
                     .ToArray();
        }

        public void AddBox(IEnumerable<NumberBox> boxes, Action<Pos[]> pointsFound, Action pointNotFound)
        {
            var range = Enumerable.Range(0, this.PosMax + 1);
            var rps =
                range.SelectMany(_ => range, (x, y) => new Pos(x, y))
                        .Where(p => !boxes.Any(box => box.X == p.X && box.Y == p.Y))
                        .ToArray();

            if (rps.Any())
            {
                pointsFound(rps);
            }
            else
            {
                Debug.Log("Cannot Add Box");
                pointNotFound();
            }
        }

        public static readonly Func<NumberBox, int> GetX = box => box.X;
        public static readonly Func<NumberBox, int> GetY = box => box.Y;

        public static readonly Func<NumberBox, int, NumberBox> MoveX = (box, x) => box.MoveX(x);
        public static readonly Func<NumberBox, int, NumberBox> MoveY = (box, y) => box.MoveY(y);

        public Func<NumberBox[], NumberBox[]> MergeLeft
        {
            get
            {
                return (boxes) => this.MergeAsc(boxes, GetY, GetX, MoveX);
            }
        }

        public Func<NumberBox[], NumberBox[]> MergeRight
        {
            get
            {
                return (boxes) => this.MergeDesc(boxes, GetY, GetX, MoveX);
            }
        }

        public Func<NumberBox[], NumberBox[]> MergeUp
        {
            get
            {
                return (boxes) => this.MergeAsc(boxes, GetX, GetY, MoveY);
            }
        }

        public Func<NumberBox[], NumberBox[]> MergeDown
        {
            get
            {
                return (boxes) => this.MergeDesc(boxes, GetX, GetY, MoveY);
            }
        }

        public bool IsDead(NumberBox[] boxes)
        {
            var hs = boxes.GroupBy(GetX).Select(g => g.OrderBy(GetY).ToArray());
            var vs = boxes.GroupBy(GetY).Select(g => g.OrderBy(GetX).ToArray());

            return !hs.Concat(vs).Any(IsMergable);
        }

        public bool IsMergable(NumberBox[] boxes)
        {
            return boxes.Zip(boxes.Skip(1), (a, b) => a.N == b.N).Any(a => a);
        }

        public NumberBox[] Bomb(NumberBox[] boxes)
        {
            var newBoxes = boxes
                .OrderByDescending(b => b.N)
                .Zip(BombPositions(), (b, p) => b.MoveX(p.X).MoveY(p.Y));
            return newBoxes.ToArray();
        }

        public IEnumerable<Pos> BombPositions()
        {
            var r = Enumerable.Range(0, 4);
            var query = from y in r
                        from x in (y % 2 == 0 ? r : r.Reverse())
                        select new Pos(x, y);
            return query;
        }
    }
}
