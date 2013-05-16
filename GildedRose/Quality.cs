﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose
{
    public struct Quality
    {
        private readonly uint value;

        public Quality(uint value)
        {
            this.value = value;
        }

        public static implicit operator Quality(int value)
        {
            return new Quality((uint)value);
        }

        public static bool operator ==(Quality left, Quality right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Quality left, Quality right)
        {
            return !left.Equals(right);
        }

        public bool IsSufficient
        {
            get { return value >= 50; }
        }

        public bool Equals(Quality other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Quality && Equals((Quality)obj);
        }

        public override int GetHashCode()
        {
            return (int)value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public Quality Decrease()
        {
            if (value > 0)
            {
                return new Quality(value - 1);
            }

            return this;
        }

        public Quality Increase()
        {
            if (!IsSufficient)
            {
                return new Quality(value + 1);
            }

            return this;
        }
    }
}