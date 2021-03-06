﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCvSharp.XImgProc;

namespace OpenCvSharp.Tests.XImgProc
{
    [TestFixture]
    public class XImgProcTest : TestBase
    {
        [Test]
        public void Thinning()
        {
            using (var src = Image("blob/shapes2.png", ImreadModes.GrayScale))
            using (var dst = new Mat())
            {
                Cv2.Thinning(src, dst, ThinningTypes.ZHANGSUEN);
                //Window.ShowImages(dst);
            }
        }

        [Test]
        public void Niblack()
        {
            using (var src = Image("lenna.png", ImreadModes.GrayScale))
            using (var dst = new Mat())
            {
                Cv2.NiblackThreshold(src, dst, 255, ThresholdTypes.Binary, 5, 0.5);
                //Window.ShowImages(dst);
            }
        }

        [Test]
        public void WeightedMedianFilter()
        {
            using (var src = Image("lenna.png", ImreadModes.GrayScale))
            using (var dst = new Mat())
            {
                Cv2.WeightedMedianFilter(src, src, dst, 7);
                //Window.ShowImages(dst);
            }
        }

        [Test]
        public void CovarianceEstimation()
        {
            const int windowSize = 7;
            using (var src = Image("lenna.png", ImreadModes.GrayScale))
            using (var dst = new Mat())
            {
                Cv2.CovarianceEstimation(src, dst, windowSize, windowSize);
                // TODO
                Assert.That(dst.Rows, Is.EqualTo(windowSize * windowSize));
                Assert.That(dst.Cols, Is.EqualTo(windowSize * windowSize));
                Assert.That(dst.Type(), Is.EqualTo(MatType.CV_32FC2));
            }
        }
    }
}

