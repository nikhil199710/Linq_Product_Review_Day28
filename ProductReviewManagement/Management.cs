using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ProductReviewManagement
{
    class ProductManagement
    {
        public readonly DataTable dataTable = new DataTable();
        /// <summary>
        /// selected records with order by clause. UC2
        /// </summary>
        /// <param name="review">The review.</param>
        public void TopRecords(List<ProductReview> listReview)
        {
            //var recordedData = (from productReviews in listReview
            //                    orderby productReviews.Rating descending
            //                    select productReviews).Take(3);

            var recordedData = listReview.OrderByDescending(productReviews => productReviews.Rating).Take(3);

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:" + list.ProductId + " UserId:" + list.UserId + " Ratings:" + list.Rating + " Review:" + list.Review + " IsLike:" + list.isLike);
            }
        }
        public void SelectedRecords(List<ProductReview> listReview)
        {
            //var recordedData = (from productReviews in listReview
            //                    where (productReviews.Rating > 3 &&(productReviews.ProductId==1|| productReviews.ProductId == 4|| productReviews.ProductId == 9))
            //                    select productReviews);

            var recordedData = listReview.Where(productReviews => (productReviews.Rating > 3 && (productReviews.ProductId == 1 || productReviews.ProductId == 4 || productReviews.ProductId == 9))).ToList();

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:" + list.ProductId + " UserId:" + list.UserId + " Ratings:" + list.Rating + " Review:" + list.Review + " IsLike:" + list.isLike);
            }

        }
        public void countOfReviews(List<ProductReview> listReview)
        {
            //var recordedData = listReview.GroupBy(r => r.ProductId).Select(r => new { ProductId = r.Key, count = r.Count() });

            var recordedData = from productReviews in listReview
                               group productReviews by productReviews.ProductId into g
                               select new
                               {
                                   ProductId = g.Key,
                                   count = g.Count()
                               };

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:" + list.count);
            }

        }
        public void retrieveProductIDandreview(List<ProductReview> listReview)
        {


            var recordedData = from productReviews in listReview
                               select new
                               {
                                   ProductId = productReviews.ProductId,
                                   Review = productReviews.Review
                               };

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId: " + list.ProductId + "  Review: " + list.Review);
            }

        }
        public void SkippingRecords(List<ProductReview> listReview)
        {
            var recordedData = (from productReviews in listReview
                                orderby productReviews.ProductId
                                select productReviews).Skip(5);

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:" + list.ProductId + " UserId:" + list.UserId + " Ratings:" + list.Rating + " Review:" + list.Review + " IsLike:" + list.isLike);
            }
        }
        public void RetreiveRecordisLike(List<ProductReview> listReview)
        {
            var recordedData = (from productReviews in listReview
                                where productReviews.isLike == true
                                select productReviews);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:" + list.ProductId + " UserId:" + list.UserId + " Ratings:" + list.Rating + " Review:" + list.Review + " IsLike:" + list.isLike);
            }

        }

        public void AverageRatingOfEachProductId(List<ProductReview> listReview)
        {
            //var recordedData = listReview.GroupBy(r => r.ProductId).Select(r => new { ProductId = r.Key, average = r.Average(x => x.Rating) });

            var recordedData = from productReviews in listReview
                               group productReviews by productReviews.ProductId into g
                               select new
                               {
                                   ProductId = g.Key,
                                   average = g.Average(productReviews => productReviews.Rating)
                               };

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId: " + list.ProductId + "  Average: " + list.average);
            }
        }
        public void RetreiveRecordReview(List<ProductReview> listReview)
        {
            var recordedData = (from productReviews in listReview
                                where productReviews.Review == "nice"
                                select productReviews);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:" + list.ProductId + " UserId:" + list.UserId + " Ratings:" + list.Rating + " Review:" + list.Review + " IsLike:" + list.isLike);
            }
        }
    }
}