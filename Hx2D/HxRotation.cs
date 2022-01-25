using System;
using Microsoft.Xna.Framework;

namespace Hx
{
    /// <summary>
    /// 
    /// </summary>
    public struct HxRotation
    {
        /// <summary>
        /// 
        /// </summary>
        private float _rotationInRad;

        /// <summary>
        /// 
        /// </summary>
        private float _rotationInDegree;

        /// <summary>
        /// 
        /// </summary>
        public float Degrees
        {
            get => GetRotation(HxRotationType.Degrees);
            set => SetRotation(value, HxRotationType.Degrees);
        }

        /// <summary>
        /// 
        /// </summary>
        public float Radians
        {
            get => GetRotation(HxRotationType.Radians);
            set => SetRotation(value, HxRotationType.Radians);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rotationValue"></param>
        /// <param name="type"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public HxRotation(float rotationValue = 0f, HxRotationType type = HxRotationType.Degrees)
        {
            switch (type)
            {
                case HxRotationType.Degrees:
                    _rotationInDegree = rotationValue;
                    _rotationInRad = HxMath.ToRadians(rotationValue);
                    break;
                case HxRotationType.Radians:
                    _rotationInDegree = HxMath.ToDegrees(rotationValue);
                    _rotationInRad = rotationValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static HxRotation FromDegrees(float degrees)
        {
            var result = new HxRotation(degrees, HxRotationType.Degrees);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static HxRotation FromRadians(float radians)
        {
            var result = new HxRotation(radians, HxRotationType.Radians);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rotationValue"></param>
        /// <param name="type"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetRotation(float rotationValue, HxRotationType type)
        {
            switch (type)
            {
                case HxRotationType.Degrees:
                    _rotationInDegree = rotationValue;
                    _rotationInRad = HxMath.ToRadians(rotationValue);
                    break;
                case HxRotationType.Radians:
                    _rotationInDegree = HxMath.ToDegrees(rotationValue);
                    _rotationInRad = rotationValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private float GetRotation(HxRotationType type)
        {
            return type switch
            {
                HxRotationType.Degrees => _rotationInDegree,
                HxRotationType.Radians => _rotationInRad,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static HxRotation operator +(HxRotation a, HxRotation b)
        {
            var result = new HxRotation(a.Degrees + b.Degrees);
            return result;
        }

        public static HxRotation operator -(HxRotation a, HxRotation b)
        {
            var result = new HxRotation(a.Degrees - b.Degrees);
            return result;
        }

        public static HxRotation operator *(HxRotation a, float value)
        {
            var result = new HxRotation(a.Degrees * value);
            return result;
        }

        public static HxRotation operator /(HxRotation a, float value)
        {
            var result = new HxRotation(a.Degrees / value);
            return result;
        }
    }
}