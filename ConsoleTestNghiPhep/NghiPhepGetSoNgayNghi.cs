using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    [TestClass()]
    public class NghiPhepGetSoNgayNghi
    {
        [TestMethod()]
        public void BUOI_SANG_BUOI_SANG_SAME_DAY()
        {
            decimal expected = 0.5M;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_SANG, NghiPhep.Constant.BUOI_SANG, DateTime.Now, DateTime.Now);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_SANG_BUOI_CHIEU_SAME_DAY()
        {
            decimal expected = 1;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_SANG, NghiPhep.Constant.BUOI_CHIEU, DateTime.Now, DateTime.Now);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_CHIEU_BUOI_SANG_SAME_DAY()
        {
            decimal expected = 0;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_CHIEU, NghiPhep.Constant.BUOI_SANG, DateTime.Now, DateTime.Now);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_SANG_BUOI_SANG_NEXT_DAY()
        {
            decimal expected = 1.5M;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_SANG, NghiPhep.Constant.BUOI_SANG, DateTime.Now, DateTime.Now.AddDays(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_SANG_BUOI_CHIEU_NEXT_DAY()
        {
            decimal expected = 2M;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_SANG, NghiPhep.Constant.BUOI_CHIEU, DateTime.Now, DateTime.Now.AddDays(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_CHIEU_BUOI_SANG_NEXT_DAY()
        {
            decimal expected = 1M;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_CHIEU, NghiPhep.Constant.BUOI_SANG, DateTime.Now, DateTime.Now.AddDays(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_CHIEU_BUOI_CHIEU_NEXT_DAY()
        {
            decimal expected = 1.5M;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_CHIEU, NghiPhep.Constant.BUOI_CHIEU, DateTime.Now, DateTime.Now.AddDays(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_SANG_BUOI_SANG_THU_SAU_THU_HAI()
        {
            decimal expected = 2M;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_SANG, NghiPhep.Constant.BUOI_SANG, new DateTime(2018, 9, 28), new DateTime(2018, 10, 1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_SANG_BUOI_CHIEU_THU_SAU_THU_HAI()
        {
            decimal expected = 2.5M;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_SANG, NghiPhep.Constant.BUOI_CHIEU, new DateTime(2018, 9, 28), new DateTime(2018, 10, 1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_SANG_BUOI_CHIEU_THU_BAY_THU_HAI()
        {
            decimal expected = 1.5M;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_SANG, NghiPhep.Constant.BUOI_CHIEU, new DateTime(2018, 9, 29), new DateTime(2018, 10, 1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_SANG_BUOI_SANG_THU_BAY_THU_HAI()
        {
            decimal expected = 1M;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_SANG, NghiPhep.Constant.BUOI_SANG, new DateTime(2018, 9, 29), new DateTime(2018, 10, 1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_SANG_BUOI_CHIEU_THU_HAI_THU_HAI()
        {
            decimal expected = 6.5M;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_SANG, NghiPhep.Constant.BUOI_CHIEU, new DateTime(2018, 10, 1), new DateTime(2018, 10, 8));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CHU_NHAT_THU_HAI()
        {
            decimal expected = 0;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_SANG, NghiPhep.Constant.BUOI_CHIEU, new DateTime(2018, 9, 30), new DateTime(2018, 10, 1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void THU_SAU_CHU_NHAT()
        {
            decimal expected = 0;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_SANG, NghiPhep.Constant.BUOI_CHIEU, new DateTime(2018, 9, 28), new DateTime(2018, 9, 30));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_CHIEU_THU_BAY_BUOI_SANG_THU_HAI()
        {
            decimal expected = 0;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_CHIEU, NghiPhep.Constant.BUOI_SANG, new DateTime(2018, 9, 29), new DateTime(2018, 10, 1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BUOI_CHIEU_THU_SAU_BUOI_CHIEU_THU_BAY()
        {
            decimal expected = 0;
            var actual = NghiPhep.GetSoNgayNghi(NghiPhep.Constant.BUOI_CHIEU, NghiPhep.Constant.BUOI_CHIEU, new DateTime(2018, 9, 28), new DateTime(2018, 9, 29));
            Assert.AreEqual(expected, actual);
        }

    }
}