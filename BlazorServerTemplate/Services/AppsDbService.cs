using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Text.Encodings.Web;
//using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using BlazorServerTemplate.Models.AppsDb;
using BlazorServerTemplate.Data;
//using ExpenseReclass.Data;
//using ExpenseReclass.Models.ExpenseReclassDb;
//using Dapper;

namespace BlazorServerTemplate.Services
{
    public partial class AppsDbService
    {
        private readonly AppsDbContext context;
//        private readonly NavigationManager navigationManager;
//        private readonly IConfiguration config;

        AppsDbContext Context
        {
            get
            {
                return this.context;
            }
        }
        public AppsDbService(AppsDbContext context
            //, NavigationManager navigationManager
            //, IConfiguration config
            )
        {
            this.context = context;
//            this.context.Database.SetCommandTimeout(int.Parse(config["CommandTimeout"]));
//            this.navigationManager = navigationManager;
//            this.config = config;         
        }

/*
        public IEnumerable<BucketAppEventLog> GetEventDurations()
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

        }
*/

        public async Task<BucketAppEventLog[]> GetFoundationJobDurationsAsync()
        {
            #region StaticTestDurations
            var AppEventLogs = new BucketAppEventLog[]
            {
                new BucketAppEventLog(19754223, "NewsDriver.ps1", "Oct  2 2022 10:00AM", "Oct  2 2022 10:00AM", 25),
                new BucketAppEventLog(19754495, "NewsDriver.ps1", "Oct  2 2022 11:00AM", "Oct  2 2022 11:00AM", 23),
                new BucketAppEventLog(19754776, "NewsDriver.ps1", "Oct  2 2022 12:00PM", "Oct  2 2022 12:00PM", 18),
                new BucketAppEventLog(19755047, "NewsDriver.ps1", "Oct  2 2022  1:00PM", "Oct  2 2022  1:00PM", 17),
                new BucketAppEventLog(19755308, "NewsDriver.ps1", "Oct  2 2022  2:00PM", "Oct  2 2022  2:00PM", 28),
                new BucketAppEventLog(19755613, "NewsDriver.ps1", "Oct  2 2022  3:00PM", "Oct  2 2022  3:00PM", 15),
                new BucketAppEventLog(19755886, "NewsDriver.ps1", "Oct  2 2022  4:00PM", "Oct  2 2022  4:00PM", 19),
                new BucketAppEventLog(19756136, "NewsDriver.ps1", "Oct  2 2022  5:00PM", "Oct  2 2022  5:00PM", 41),
                new BucketAppEventLog(19756444, "NewsDriver.ps1", "Oct  2 2022  6:00PM", "Oct  2 2022  6:01PM", 31),
                new BucketAppEventLog(19756732, "NewsDriver.ps1", "Oct  2 2022  7:00PM", "Oct  2 2022  7:00PM", 16),
                new BucketAppEventLog(19757008, "NewsDriver.ps1", "Oct  2 2022  8:00PM", "Oct  2 2022  8:00PM", 22),
                new BucketAppEventLog(19757151, "RubyDriver.ps1", "Oct  2 2022  8:30PM", "Oct  2 2022  8:36PM", 358),
                new BucketAppEventLog(19757155, "Full Pull", "Oct  2 2022  8:30PM", "Oct  2 2022  8:36PM", 354),
                new BucketAppEventLog(19757369, "GetPersonnelPics.ps1", "Oct  2 2022  9:30PM", "Oct  2 2022  9:30PM", 4),
                new BucketAppEventLog(19757693, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct  2 2022 11:00PM", "Oct  3 2022 12:16AM", 4568),
                new BucketAppEventLog(19759215, "NewsDriver.ps1", "Oct  3 2022  6:00AM", "Oct  3 2022  6:01AM", 32),
                new BucketAppEventLog(19759477, "NewsDriver.ps1", "Oct  3 2022  7:01AM", "Oct  3 2022  7:03AM", 132),
                new BucketAppEventLog(19759770, "NewsDriver.ps1", "Oct  3 2022  8:00AM", "Oct  3 2022  8:00AM", 13),
                new BucketAppEventLog(19760010, "NewsDriver.ps1", "Oct  3 2022  9:00AM", "Oct  3 2022  9:00AM", 9),
                new BucketAppEventLog(19761650, "NewsDriver.ps1", "Oct  3 2022  4:55PM", "Oct  3 2022  4:55PM", 12),
                new BucketAppEventLog(19761724, "NewsDriver.ps1", "Oct  3 2022  5:05PM", "Oct  3 2022  5:05PM", 11),
                new BucketAppEventLog(19761960, "NewsDriver.ps1", "Oct  3 2022  6:00PM", "Oct  3 2022  6:00PM", 10),
                new BucketAppEventLog(19762240, "NewsDriver.ps1", "Oct  3 2022  7:00PM", "Oct  3 2022  7:00PM", 12),
                new BucketAppEventLog(19762518, "NewsDriver.ps1", "Oct  3 2022  8:00PM", "Oct  3 2022  8:00PM", 9),
                new BucketAppEventLog(19762670, "RubyDriver.ps1", "Oct  3 2022  8:30PM", "Oct  3 2022  8:36PM", 388),
                new BucketAppEventLog(19762688, "Full Pull", "Oct  3 2022  8:30PM", "Oct  3 2022  8:36PM", 382),
                new BucketAppEventLog(19762893, "GetPersonnelPics.ps1", "Oct  3 2022  9:30PM", "Oct  3 2022  9:30PM", 13),
                new BucketAppEventLog(19763210, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct  3 2022 11:00PM", "Oct  4 2022 12:12AM", 4357),
                new BucketAppEventLog(19764737, "NewsDriver.ps1", "Oct  4 2022  6:00AM", "Oct  4 2022  6:00AM", 17),
                new BucketAppEventLog(19764984, "NewsDriver.ps1", "Oct  4 2022  7:00AM", "Oct  4 2022  7:00AM", 8),
                new BucketAppEventLog(19765290, "NewsDriver.ps1", "Oct  4 2022  8:00AM", "Oct  4 2022  8:00AM", 8),
                new BucketAppEventLog(19765580, "NewsDriver.ps1", "Oct  4 2022  9:05AM", "Oct  4 2022  9:05AM", 9),
                new BucketAppEventLog(19765840, "NewsDriver.ps1", "Oct  4 2022 10:00AM", "Oct  4 2022 10:00AM", 11),
                new BucketAppEventLog(19766124, "NewsDriver.ps1", "Oct  4 2022 11:00AM", "Oct  4 2022 11:00AM", 10),
                new BucketAppEventLog(19766370, "NewsDriver.ps1", "Oct  4 2022 12:00PM", "Oct  4 2022 12:00PM", 8),
                new BucketAppEventLog(19766677, "NewsDriver.ps1", "Oct  4 2022  1:05PM", "Oct  4 2022  1:05PM", 8),
                new BucketAppEventLog(19766756, "NewsDriver.ps1", "Oct  4 2022  1:25PM", "Oct  4 2022  1:25PM", 9),
                new BucketAppEventLog(19766909, "NewsDriver.ps1", "Oct  4 2022  2:00PM", "Oct  4 2022  2:00PM", 11),
                new BucketAppEventLog(19767208, "NewsDriver.ps1", "Oct  4 2022  3:00PM", "Oct  4 2022  3:00PM", 11),
                new BucketAppEventLog(19767470, "NewsDriver.ps1", "Oct  4 2022  4:00PM", "Oct  4 2022  4:00PM", 8),
                new BucketAppEventLog(19767764, "NewsDriver.ps1", "Oct  4 2022  5:00PM", "Oct  4 2022  5:00PM", 9),
                new BucketAppEventLog(19768033, "NewsDriver.ps1", "Oct  4 2022  6:00PM", "Oct  4 2022  6:00PM", 11),
                new BucketAppEventLog(19768347, "NewsDriver.ps1", "Oct  4 2022  7:00PM", "Oct  4 2022  7:00PM", 9),
                new BucketAppEventLog(19768634, "NewsDriver.ps1", "Oct  4 2022  8:00PM", "Oct  4 2022  8:00PM", 10),
                new BucketAppEventLog(19768783, "RubyDriver.ps1", "Oct  4 2022  8:30PM", "Oct  4 2022  8:36PM", 340),
                new BucketAppEventLog(19768786, "Full Pull", "Oct  4 2022  8:30PM", "Oct  4 2022  8:36PM", 336),
                new BucketAppEventLog(19769010, "GetPersonnelPics.ps1", "Oct  4 2022  9:30PM", "Oct  4 2022  9:30PM", 5),
                new BucketAppEventLog(19769310, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct  4 2022 11:00PM", "Oct  5 2022 12:10AM", 4238),
                new BucketAppEventLog(19770834, "NewsDriver.ps1", "Oct  5 2022  6:00AM", "Oct  5 2022  6:00AM", 21),
                new BucketAppEventLog(19771157, "NewsDriver.ps1", "Oct  5 2022  7:05AM", "Oct  5 2022  7:05AM", 9),
                new BucketAppEventLog(19771409, "NewsDriver.ps1", "Oct  5 2022  8:00AM", "Oct  5 2022  8:00AM", 12),
                new BucketAppEventLog(19771706, "NewsDriver.ps1", "Oct  5 2022  9:05AM", "Oct  5 2022  9:05AM", 10),
                new BucketAppEventLog(19771963, "NewsDriver.ps1", "Oct  5 2022 10:00AM", "Oct  5 2022 10:00AM", 13),
                new BucketAppEventLog(19772210, "NewsDriver.ps1", "Oct  5 2022 11:00AM", "Oct  5 2022 11:00AM", 22),
                new BucketAppEventLog(19772526, "NewsDriver.ps1", "Oct  5 2022 12:00PM", "Oct  5 2022 12:00PM", 16),
                new BucketAppEventLog(19772769, "NewsDriver.ps1", "Oct  5 2022  1:00PM", "Oct  5 2022  1:00PM", 19),
                new BucketAppEventLog(19773071, "NewsDriver.ps1", "Oct  5 2022  2:00PM", "Oct  5 2022  2:00PM", 13),
                new BucketAppEventLog(19773337, "NewsDriver.ps1", "Oct  5 2022  3:00PM", "Oct  5 2022  3:00PM", 12),
                new BucketAppEventLog(19773631, "NewsDriver.ps1", "Oct  5 2022  4:00PM", "Oct  5 2022  4:00PM", 10),
                new BucketAppEventLog(19773905, "NewsDriver.ps1", "Oct  5 2022  5:00PM", "Oct  5 2022  5:00PM", 14),
                new BucketAppEventLog(19774211, "NewsDriver.ps1", "Oct  5 2022  6:00PM", "Oct  5 2022  6:00PM", 11),
                new BucketAppEventLog(19774483, "NewsDriver.ps1", "Oct  5 2022  7:00PM", "Oct  5 2022  7:00PM", 21),
                new BucketAppEventLog(19774764, "NewsDriver.ps1", "Oct  5 2022  8:00PM", "Oct  5 2022  8:00PM", 13),
                new BucketAppEventLog(19774914, "RubyDriver.ps1", "Oct  5 2022  8:30PM", "Oct  5 2022  8:36PM", 369),
                new BucketAppEventLog(19774934, "Full Pull", "Oct  5 2022  8:30PM", "Oct  5 2022  8:36PM", 362),
                new BucketAppEventLog(19775170, "GetPersonnelPics.ps1", "Oct  5 2022  9:30PM", "Oct  5 2022  9:30PM", 2),
                new BucketAppEventLog(19775477, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct  5 2022 11:00PM", "Oct  6 2022 12:12AM", 4356),
                new BucketAppEventLog(19776994, "NewsDriver.ps1", "Oct  6 2022  6:00AM", "Oct  6 2022  6:00AM", 16),
                new BucketAppEventLog(19777252, "NewsDriver.ps1", "Oct  6 2022  7:00AM", "Oct  6 2022  7:00AM", 12),
                new BucketAppEventLog(19777573, "NewsDriver.ps1", "Oct  6 2022  8:00AM", "Oct  6 2022  8:00AM", 8),
                new BucketAppEventLog(19777823, "NewsDriver.ps1", "Oct  6 2022  9:00AM", "Oct  6 2022  9:00AM", 12),
                new BucketAppEventLog(19778066, "NewsDriver.ps1", "Oct  6 2022 10:00AM", "Oct  6 2022 10:00AM", 25),
                new BucketAppEventLog(19778412, "NewsDriver.ps1", "Oct  6 2022 11:05AM", "Oct  6 2022 11:05AM", 7),
                new BucketAppEventLog(19778625, "NewsDriver.ps1", "Oct  6 2022 12:00PM", "Oct  6 2022 12:00PM", 10),
                new BucketAppEventLog(19778956, "RubyDriver.ps1", "Oct  6 2022  1:02PM", "Oct  6 2022  1:03PM", 25),
                new BucketAppEventLog(19778957, "Full Pull", "Oct  6 2022  1:02PM", "Oct  6 2022  1:03PM", 23),
                new BucketAppEventLog(19778965, "NewsDriver.ps1", "Oct  6 2022  1:05PM", "Oct  6 2022  1:05PM", 8),
                new BucketAppEventLog(19779039, "RubyDriver.ps1", "Oct  6 2022  1:21PM", "Oct  6 2022  1:21PM", 25),
                new BucketAppEventLog(19779040, "Full Pull", "Oct  6 2022  1:21PM", "Oct  6 2022  1:21PM", 24),
                new BucketAppEventLog(19779041, "RubyDriver.ps1", "Oct  6 2022  1:21PM", "Oct  6 2022  1:21PM", 24),
                new BucketAppEventLog(19779042, "Full Pull", "Oct  6 2022  1:21PM", "Oct  6 2022  1:21PM", 22),
                new BucketAppEventLog(19779194, "NewsDriver.ps1", "Oct  6 2022  2:00PM", "Oct  6 2022  2:00PM", 27),
                new BucketAppEventLog(19779496, "NewsDriver.ps1", "Oct  6 2022  3:00PM", "Oct  6 2022  3:00PM", 15),
                new BucketAppEventLog(19779757, "NewsDriver.ps1", "Oct  6 2022  4:00PM", "Oct  6 2022  4:00PM", 11),
                new BucketAppEventLog(19780051, "NewsDriver.ps1", "Oct  6 2022  5:00PM", "Oct  6 2022  5:00PM", 17),
                new BucketAppEventLog(19780311, "NewsDriver.ps1", "Oct  6 2022  6:00PM", "Oct  6 2022  6:00PM", 11),
                new BucketAppEventLog(19780554, "NewsDriver.ps1", "Oct  6 2022  7:00PM", "Oct  6 2022  7:00PM", 9),
                new BucketAppEventLog(19780882, "NewsDriver.ps1", "Oct  6 2022  8:05PM", "Oct  6 2022  8:05PM", 7),
                new BucketAppEventLog(19780958, "RubyDriver.ps1", "Oct  6 2022  8:30PM", "Oct  6 2022  8:36PM", 386),
                new BucketAppEventLog(19780969, "Full Pull", "Oct  6 2022  8:30PM", "Oct  6 2022  8:36PM", 377),
                new BucketAppEventLog(19781214, "GetPersonnelPics.ps1", "Oct  6 2022  9:30PM", "Oct  6 2022  9:30PM", 8),
                new BucketAppEventLog(19781540, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct  6 2022 11:00PM", "Oct  7 2022 12:16AM", 4567),
                new BucketAppEventLog(19783016, "NewsDriver.ps1", "Oct  7 2022  6:00AM", "Oct  7 2022  6:00AM", 10),
                new BucketAppEventLog(19783302, "NewsDriver.ps1", "Oct  7 2022  7:00AM", "Oct  7 2022  7:00AM", 7),
                new BucketAppEventLog(19783580, "NewsDriver.ps1", "Oct  7 2022  8:00AM", "Oct  7 2022  8:00AM", 10),
                new BucketAppEventLog(19783883, "NewsDriver.ps1", "Oct  7 2022  9:00AM", "Oct  7 2022  9:00AM", 7),
                new BucketAppEventLog(19784149, "NewsDriver.ps1", "Oct  7 2022 10:00AM", "Oct  7 2022 10:00AM", 12),
                new BucketAppEventLog(19784409, "NewsDriver.ps1", "Oct  7 2022 11:00AM", "Oct  7 2022 11:00AM", 10),
                new BucketAppEventLog(19784739, "NewsDriver.ps1", "Oct  7 2022 12:05PM", "Oct  7 2022 12:05PM", 8),
                new BucketAppEventLog(19784962, "NewsDriver.ps1", "Oct  7 2022  1:00PM", "Oct  7 2022  1:00PM", 8),
                new BucketAppEventLog(19785294, "NewsDriver.ps1", "Oct  7 2022  2:05PM", "Oct  7 2022  2:05PM", 4),
                new BucketAppEventLog(19785547, "NewsDriver.ps1", "Oct  7 2022  3:00PM", "Oct  7 2022  3:00PM", 6),
                new BucketAppEventLog(19785789, "NewsDriver.ps1", "Oct  7 2022  4:00PM", "Oct  7 2022  4:00PM", 5),
                new BucketAppEventLog(19786069, "NewsDriver.ps1", "Oct  7 2022  5:00PM", "Oct  7 2022  5:00PM", 4),
                new BucketAppEventLog(19786358, "NewsDriver.ps1", "Oct  7 2022  6:00PM", "Oct  7 2022  6:00PM", 4),
                new BucketAppEventLog(19786618, "NewsDriver.ps1", "Oct  7 2022  7:00PM", "Oct  7 2022  7:00PM", 20),
                new BucketAppEventLog(19786927, "NewsDriver.ps1", "Oct  7 2022  8:00PM", "Oct  7 2022  8:00PM", 5),
                new BucketAppEventLog(19787067, "RubyDriver.ps1", "Oct  7 2022  8:30PM", "Oct  7 2022  8:31PM", 62),
                new BucketAppEventLog(19787071, "Full Pull", "Oct  7 2022  8:30PM", "Oct  7 2022  8:31PM", 59),
                new BucketAppEventLog(19787308, "GetPersonnelPics.ps1", "Oct  7 2022  9:30PM", "Oct  7 2022  9:30PM", 4),
                new BucketAppEventLog(19787614, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct  7 2022 11:00PM", "Oct  8 2022 12:18AM", 4719),
                new BucketAppEventLog(19789118, "NewsDriver.ps1", "Oct  8 2022  6:00AM", "Oct  8 2022  6:00AM", 15),
                new BucketAppEventLog(19789449, "NewsDriver.ps1", "Oct  8 2022  7:05AM", "Oct  8 2022  7:05AM", 4),
                new BucketAppEventLog(19789663, "NewsDriver.ps1", "Oct  8 2022  8:00AM", "Oct  8 2022  8:00AM", 5),
                new BucketAppEventLog(19789933, "NewsDriver.ps1", "Oct  8 2022  9:00AM", "Oct  8 2022  9:00AM", 6),
                new BucketAppEventLog(19790221, "NewsDriver.ps1", "Oct  8 2022 10:00AM", "Oct  8 2022 10:00AM", 8),
                new BucketAppEventLog(19790490, "NewsDriver.ps1", "Oct  8 2022 11:00AM", "Oct  8 2022 11:00AM", 19),
                new BucketAppEventLog(19790793, "NewsDriver.ps1", "Oct  8 2022 12:00PM", "Oct  8 2022 12:00PM", 9),
                new BucketAppEventLog(19791047, "NewsDriver.ps1", "Oct  8 2022  1:00PM", "Oct  8 2022  1:00PM", 6),
                new BucketAppEventLog(19791358, "NewsDriver.ps1", "Oct  8 2022  2:00PM", "Oct  8 2022  2:00PM", 7),
                new BucketAppEventLog(19791654, "NewsDriver.ps1", "Oct  8 2022  3:00PM", "Oct  8 2022  3:00PM", 7),
                new BucketAppEventLog(19791708, "NewsDriver.ps1", "Oct  8 2022  3:14PM", "Oct  8 2022  3:14PM", 7),
                new BucketAppEventLog(19791922, "NewsDriver.ps1", "Oct  8 2022  4:00PM", "Oct  8 2022  4:00PM", 17),
                new BucketAppEventLog(19792229, "NewsDriver.ps1", "Oct  8 2022  5:00PM", "Oct  8 2022  5:00PM", 11),
                new BucketAppEventLog(19792464, "NewsDriver.ps1", "Oct  8 2022  6:00PM", "Oct  8 2022  6:00PM", 23),
                new BucketAppEventLog(19792787, "NewsDriver.ps1", "Oct  8 2022  7:00PM", "Oct  8 2022  7:00PM", 10),
                new BucketAppEventLog(19793062, "NewsDriver.ps1", "Oct  8 2022  8:00PM", "Oct  8 2022  8:00PM", 14),
                new BucketAppEventLog(19793195, "RubyDriver.ps1", "Oct  8 2022  8:30PM", "Oct  8 2022  8:32PM", 108),
                new BucketAppEventLog(19793206, "Full Pull", "Oct  8 2022  8:30PM", "Oct  8 2022  8:32PM", 102),
                new BucketAppEventLog(19793410, "GetPersonnelPics.ps1", "Oct  8 2022  9:30PM", "Oct  8 2022  9:30PM", 10),
                new BucketAppEventLog(19793766, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct  8 2022 11:00PM", "Oct  9 2022 12:09AM", 4146),
                new BucketAppEventLog(19794107, "RubyDriver.ps1", "Oct  9 2022 12:45AM", "Oct  9 2022 12:46AM", 115),
                new BucketAppEventLog(19794110, "Full Pull", "Oct  9 2022 12:45AM", "Oct  9 2022 12:46AM", 109),
                new BucketAppEventLog(19794144, "RubyDriver.ps1", "Oct  9 2022 12:51AM", "Oct  9 2022  1:01AM", 595),
                new BucketAppEventLog(19794145, "Full Pull", "Oct  9 2022 12:51AM", "Oct  9 2022  1:01AM", 593),
                new BucketAppEventLog(19794357, "RubyDriver.ps1", "Oct  9 2022  1:53AM", "Oct  9 2022  2:06AM", 789),
                new BucketAppEventLog(19794358, "Full Pull", "Oct  9 2022  1:53AM", "Oct  9 2022  2:06AM", 787),
                new BucketAppEventLog(19794366, "RubyDriver.ps1", "Oct  9 2022  1:59AM", "Oct  9 2022  2:06AM", 395),
                new BucketAppEventLog(19794367, "Full Pull", "Oct  9 2022  1:59AM", "Oct  9 2022  2:06AM", 393),
                new BucketAppEventLog(19795246, "NewsDriver.ps1", "Oct  9 2022  6:00AM", "Oct  9 2022  6:00AM", 15),
                new BucketAppEventLog(19795277, "MarketCap.ps1", "Oct  9 2022  6:00AM", "", 0),
                new BucketAppEventLog(19795560, "NewsDriver.ps1", "Oct  9 2022  7:00AM", "Oct  9 2022  7:01AM", 44),
                new BucketAppEventLog(19795794, "NewsDriver.ps1", "Oct  9 2022  7:49AM", "Oct  9 2022  7:49AM", 7),
                new BucketAppEventLog(19795807, "RubyDriver.ps1", "Oct  9 2022  7:57AM", "Oct  9 2022  8:02AM", 311),
                new BucketAppEventLog(19795808, "Full Pull", "Oct  9 2022  7:57AM", "Oct  9 2022  8:02AM", 309),
                new BucketAppEventLog(19795885, "NewsDriver.ps1", "Oct  9 2022  8:05AM", "Oct  9 2022  8:05AM", 8),
                new BucketAppEventLog(19796112, "NewsDriver.ps1", "Oct  9 2022  9:00AM", "Oct  9 2022  9:00AM", 17),
                new BucketAppEventLog(19796164, "RubyDriver.ps1", "Oct  9 2022  9:10AM", "Oct  9 2022  9:16AM", 372),
                new BucketAppEventLog(19796165, "Full Pull", "Oct  9 2022  9:10AM", "Oct  9 2022  9:16AM", 371),
                new BucketAppEventLog(19796299, "RubyDriver.ps1", "Oct  9 2022  9:40AM", "Oct  9 2022  9:44AM", 248),
                new BucketAppEventLog(19796300, "Full Pull", "Oct  9 2022  9:40AM", "Oct  9 2022  9:44AM", 246),
                new BucketAppEventLog(19796301, "RubyDriver.ps1", "Oct  9 2022  9:41AM", "Oct  9 2022  9:44AM", 202),
                new BucketAppEventLog(19796302, "Full Pull", "Oct  9 2022  9:41AM", "Oct  9 2022  9:44AM", 200),
                new BucketAppEventLog(19796358, "NewsDriver.ps1", "Oct  9 2022  9:59AM", "Oct  9 2022  9:59AM", 7),
                new BucketAppEventLog(19796425, "NewsDriver.ps1", "Oct  9 2022 10:00AM", "Oct  9 2022 10:00AM", 10),
                new BucketAppEventLog(19796658, "NewsDriver.ps1", "Oct  9 2022 11:00AM", "Oct  9 2022 11:00AM", 19),
                new BucketAppEventLog(19796933, "NewsDriver.ps1", "Oct  9 2022 12:00PM", "Oct  9 2022 12:00PM", 18),
                new BucketAppEventLog(19797208, "NewsDriver.ps1", "Oct  9 2022  1:00PM", "Oct  9 2022  1:00PM", 10),
                new BucketAppEventLog(19797510, "NewsDriver.ps1", "Oct  9 2022  2:00PM", "Oct  9 2022  2:00PM", 17),
                new BucketAppEventLog(19797784, "NewsDriver.ps1", "Oct  9 2022  3:00PM", "Oct  9 2022  3:00PM", 26),
                new BucketAppEventLog(19798088, "NewsDriver.ps1", "Oct  9 2022  4:00PM", "Oct  9 2022  4:00PM", 14),
                new BucketAppEventLog(19798415, "NewsDriver.ps1", "Oct  9 2022  5:05PM", "Oct  9 2022  5:05PM", 7),
                new BucketAppEventLog(19798657, "NewsDriver.ps1", "Oct  9 2022  6:00PM", "Oct  9 2022  6:00PM", 15),
                new BucketAppEventLog(19798954, "NewsDriver.ps1", "Oct  9 2022  7:00PM", "Oct  9 2022  7:00PM", 12),
                new BucketAppEventLog(19799225, "NewsDriver.ps1", "Oct  9 2022  8:00PM", "Oct  9 2022  8:00PM", 14),
                new BucketAppEventLog(19799578, "GetPersonnelPics.ps1", "Oct  9 2022  9:30PM", "Oct  9 2022  9:30PM", 15),
                new BucketAppEventLog(19799919, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct  9 2022 11:00PM", "Oct 10 2022  7:29AM", 30577),
                new BucketAppEventLog(19801444, "NewsDriver.ps1", "Oct 10 2022  6:00AM", "Oct 10 2022  6:00AM", 16),
                new BucketAppEventLog(19801547, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 10 2022  6:20AM", "Oct 10 2022  7:29AM", 4177),
                new BucketAppEventLog(19801688, "NewsDriver.ps1", "Oct 10 2022  7:00AM", "Oct 10 2022  7:00AM", 8),
                new BucketAppEventLog(19802016, "NewsDriver.ps1", "Oct 10 2022  8:00AM", "Oct 10 2022  8:00AM", 9),
                new BucketAppEventLog(19802274, "NewsDriver.ps1", "Oct 10 2022  9:00AM", "Oct 10 2022  9:00AM", 8),
                new BucketAppEventLog(19802550, "NewsDriver.ps1", "Oct 10 2022 10:00AM", "Oct 10 2022 10:00AM", 8),
                new BucketAppEventLog(19802828, "NewsDriver.ps1", "Oct 10 2022 11:00AM", "Oct 10 2022 11:00AM", 8),
                new BucketAppEventLog(19803094, "NewsDriver.ps1", "Oct 10 2022 12:00PM", "Oct 10 2022 12:00PM", 10),
                new BucketAppEventLog(19803362, "NewsDriver.ps1", "Oct 10 2022  1:00PM", "Oct 10 2022  1:00PM", 6),
                new BucketAppEventLog(19803641, "NewsDriver.ps1", "Oct 10 2022  2:00PM", "Oct 10 2022  2:00PM", 6),
                new BucketAppEventLog(19803943, "NewsDriver.ps1", "Oct 10 2022  3:00PM", "Oct 10 2022  3:00PM", 8),
                new BucketAppEventLog(19804236, "NewsDriver.ps1", "Oct 10 2022  4:00PM", "Oct 10 2022  4:00PM", 13),
                new BucketAppEventLog(19804505, "NewsDriver.ps1", "Oct 10 2022  5:00PM", "Oct 10 2022  5:00PM", 7),
                new BucketAppEventLog(19804795, "NewsDriver.ps1", "Oct 10 2022  6:00PM", "Oct 10 2022  6:00PM", 9),
                new BucketAppEventLog(19805112, "NewsDriver.ps1", "Oct 10 2022  7:00PM", "Oct 10 2022  7:00PM", 8),
                new BucketAppEventLog(19805396, "NewsDriver.ps1", "Oct 10 2022  8:00PM", "Oct 10 2022  8:00PM", 12),
                new BucketAppEventLog(19805773, "GetPersonnelPics.ps1", "Oct 10 2022  9:30PM", "Oct 10 2022  9:30PM", 3),
                new BucketAppEventLog(19806107, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 10 2022 11:00PM", "Oct 11 2022 12:17AM", 4630),
                new BucketAppEventLog(19807616, "NewsDriver.ps1", "Oct 11 2022  6:00AM", "Oct 11 2022  6:00AM", 27),
                new BucketAppEventLog(19807907, "NewsDriver.ps1", "Oct 11 2022  7:00AM", "Oct 11 2022  7:00AM", 18),
                new BucketAppEventLog(19808224, "NewsDriver.ps1", "Oct 11 2022  8:00AM", "Oct 11 2022  8:00AM", 15),
                new BucketAppEventLog(19808502, "NewsDriver.ps1", "Oct 11 2022  9:00AM", "Oct 11 2022  9:00AM", 10),
                new BucketAppEventLog(19808735, "NewsDriver.ps1", "Oct 11 2022 10:00AM", "Oct 11 2022 10:00AM", 16),
                new BucketAppEventLog(19809067, "NewsDriver.ps1", "Oct 11 2022 11:00AM", "Oct 11 2022 11:00AM", 10),
                new BucketAppEventLog(19809325, "NewsDriver.ps1", "Oct 11 2022 12:00PM", "Oct 11 2022 12:00PM", 29),
                new BucketAppEventLog(19809586, "NewsDriver.ps1", "Oct 11 2022  1:00PM", "Oct 11 2022  1:00PM", 10),
                new BucketAppEventLog(19809905, "NewsDriver.ps1", "Oct 11 2022  2:00PM", "Oct 11 2022  2:00PM", 24),
                new BucketAppEventLog(19810168, "NewsDriver.ps1", "Oct 11 2022  3:00PM", "Oct 11 2022  3:00PM", 22),
                new BucketAppEventLog(19810496, "NewsDriver.ps1", "Oct 11 2022  4:00PM", "Oct 11 2022  4:00PM", 9),
                new BucketAppEventLog(19810792, "NewsDriver.ps1", "Oct 11 2022  5:05PM", "Oct 11 2022  5:05PM", 8),
                new BucketAppEventLog(19811052, "NewsDriver.ps1", "Oct 11 2022  6:00PM", "Oct 11 2022  6:00PM", 23),
                new BucketAppEventLog(19811319, "NewsDriver.ps1", "Oct 11 2022  7:00PM", "Oct 11 2022  7:00PM", 11),
                new BucketAppEventLog(19811613, "NewsDriver.ps1", "Oct 11 2022  8:00PM", "Oct 11 2022  8:00PM", 12),
                new BucketAppEventLog(19811986, "GetPersonnelPics.ps1", "Oct 11 2022  9:30PM", "Oct 11 2022  9:30PM", 4),
                new BucketAppEventLog(19812309, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 11 2022 11:00PM", "Oct 12 2022 12:13AM", 4419),
                new BucketAppEventLog(19813807, "NewsDriver.ps1", "Oct 12 2022  6:00AM", "Oct 12 2022  6:01AM", 57),
                new BucketAppEventLog(19814122, "NewsDriver.ps1", "Oct 12 2022  7:00AM", "Oct 12 2022  7:01AM", 28),
                new BucketAppEventLog(19814398, "NewsDriver.ps1", "Oct 12 2022  8:00AM", "Oct 12 2022  8:00AM", 13),
                new BucketAppEventLog(19814664, "NewsDriver.ps1", "Oct 12 2022  9:00AM", "Oct 12 2022  9:00AM", 12),
                new BucketAppEventLog(19814957, "NewsDriver.ps1", "Oct 12 2022 10:00AM", "Oct 12 2022 10:00AM", 14),
                new BucketAppEventLog(19815211, "NewsDriver.ps1", "Oct 12 2022 11:00AM", "Oct 12 2022 11:00AM", 23),
                new BucketAppEventLog(19815559, "NewsDriver.ps1", "Oct 12 2022 12:05PM", "Oct 12 2022 12:05PM", 8),
                new BucketAppEventLog(19815834, "NewsDriver.ps1", "Oct 12 2022  1:00PM", "Oct 12 2022  1:00PM", 13),
                new BucketAppEventLog(19816127, "NewsDriver.ps1", "Oct 12 2022  2:00PM", "Oct 12 2022  2:00PM", 24),
                new BucketAppEventLog(19816429, "NewsDriver.ps1", "Oct 12 2022  3:00PM", "Oct 12 2022  3:00PM", 8),
                new BucketAppEventLog(19816718, "NewsDriver.ps1", "Oct 12 2022  4:00PM", "Oct 12 2022  4:00PM", 12),
                new BucketAppEventLog(19817000, "NewsDriver.ps1", "Oct 12 2022  5:00PM", "Oct 12 2022  5:00PM", 21),
                new BucketAppEventLog(19817246, "NewsDriver.ps1", "Oct 12 2022  6:00PM", "Oct 12 2022  6:00PM", 34),
                new BucketAppEventLog(19817562, "NewsDriver.ps1", "Oct 12 2022  7:00PM", "Oct 12 2022  7:00PM", 14),
                new BucketAppEventLog(19817807, "NewsDriver.ps1", "Oct 12 2022  8:00PM", "Oct 12 2022  8:00PM", 20),
                new BucketAppEventLog(19818188, "GetPersonnelPics.ps1", "Oct 12 2022  9:30PM", "Oct 12 2022  9:30PM", 8),
                new BucketAppEventLog(19818541, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 12 2022 11:00PM", "Oct 13 2022 12:19AM", 4748),
                new BucketAppEventLog(19820094, "NewsDriver.ps1", "Oct 13 2022  6:05AM", "Oct 13 2022  6:05AM", 9),
                new BucketAppEventLog(19820313, "NewsDriver.ps1", "Oct 13 2022  7:00AM", "Oct 13 2022  7:00AM", 27),
                new BucketAppEventLog(19820632, "NewsDriver.ps1", "Oct 13 2022  8:00AM", "Oct 13 2022  8:00AM", 17),
                new BucketAppEventLog(19820862, "NewsDriver.ps1", "Oct 13 2022  9:00AM", "Oct 13 2022  9:00AM", 8),
                new BucketAppEventLog(19821183, "NewsDriver.ps1", "Oct 13 2022 10:00AM", "Oct 13 2022 10:00AM", 20),
                new BucketAppEventLog(19821465, "NewsDriver.ps1", "Oct 13 2022 11:00AM", "Oct 13 2022 11:00AM", 14),
                new BucketAppEventLog(19821749, "NewsDriver.ps1", "Oct 13 2022 12:00PM", "Oct 13 2022 12:00PM", 17),
                new BucketAppEventLog(19821971, "RubyDriver.ps1", "Oct 13 2022 12:57PM", "Oct 13 2022  1:02PM", 312),
                new BucketAppEventLog(19821972, "Full Pull", "Oct 13 2022 12:57PM", "Oct 13 2022  1:02PM", 310),
                new BucketAppEventLog(19821989, "NewsDriver.ps1", "Oct 13 2022  1:00PM", "Oct 13 2022  1:00PM", 41),
                new BucketAppEventLog(19822266, "NewsDriver.ps1", "Oct 13 2022  2:00PM", "Oct 13 2022  2:00PM", 22),
                new BucketAppEventLog(19822570, "NewsDriver.ps1", "Oct 13 2022  3:00PM", "Oct 13 2022  3:00PM", 10),
                new BucketAppEventLog(19822859, "NewsDriver.ps1", "Oct 13 2022  4:00PM", "Oct 13 2022  4:00PM", 14),
                new BucketAppEventLog(19823129, "NewsDriver.ps1", "Oct 13 2022  5:00PM", "Oct 13 2022  5:00PM", 12),
                new BucketAppEventLog(19823356, "NewsDriver.ps1", "Oct 13 2022  5:59PM", "Oct 13 2022  6:00PM", 18),
                new BucketAppEventLog(19823676, "NewsDriver.ps1", "Oct 13 2022  7:00PM", "Oct 13 2022  7:00PM", 8),
                new BucketAppEventLog(19823922, "NewsDriver.ps1", "Oct 13 2022  8:00PM", "Oct 13 2022  8:00PM", 24),
                new BucketAppEventLog(19824075, "RubyDriver.ps1", "Oct 13 2022  8:30PM", "Oct 13 2022  8:36PM", 364),
                new BucketAppEventLog(19824088, "Full Pull", "Oct 13 2022  8:30PM", "Oct 13 2022  8:36PM", 360),
                new BucketAppEventLog(19824320, "GetPersonnelPics.ps1", "Oct 13 2022  9:30PM", "Oct 13 2022  9:30PM", 14),
                new BucketAppEventLog(19824637, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 13 2022 11:00PM", "Oct 14 2022 12:11AM", 4239),
                new BucketAppEventLog(19826170, "NewsDriver.ps1", "Oct 14 2022  6:00AM", "Oct 14 2022  6:00AM", 15),
                new BucketAppEventLog(19826466, "NewsDriver.ps1", "Oct 14 2022  7:00AM", "Oct 14 2022  7:00AM", 10),
                new BucketAppEventLog(19826741, "NewsDriver.ps1", "Oct 14 2022  8:00AM", "Oct 14 2022  8:00AM", 7),
                new BucketAppEventLog(19827013, "NewsDriver.ps1", "Oct 14 2022  9:00AM", "Oct 14 2022  9:00AM", 8),
                new BucketAppEventLog(19827273, "NewsDriver.ps1", "Oct 14 2022 10:00AM", "Oct 14 2022 10:00AM", 8),
                new BucketAppEventLog(19827526, "NewsDriver.ps1", "Oct 14 2022 11:00AM", "Oct 14 2022 11:00AM", 14),
                new BucketAppEventLog(19827808, "NewsDriver.ps1", "Oct 14 2022 12:00PM", "Oct 14 2022 12:00PM", 11),
                new BucketAppEventLog(19828112, "NewsDriver.ps1", "Oct 14 2022  1:00PM", "Oct 14 2022  1:00PM", 15),
                new BucketAppEventLog(19828398, "NewsDriver.ps1", "Oct 14 2022  2:00PM", "Oct 14 2022  2:00PM", 10),
                new BucketAppEventLog(19828689, "NewsDriver.ps1", "Oct 14 2022  3:00PM", "Oct 14 2022  3:00PM", 6),
                new BucketAppEventLog(19828994, "NewsDriver.ps1", "Oct 14 2022  4:05PM", "Oct 14 2022  4:05PM", 6),
                new BucketAppEventLog(19829273, "NewsDriver.ps1", "Oct 14 2022  5:05PM", "Oct 14 2022  5:05PM", 7),
                new BucketAppEventLog(19829491, "NewsDriver.ps1", "Oct 14 2022  6:00PM", "Oct 14 2022  6:00PM", 13),
                new BucketAppEventLog(19829783, "NewsDriver.ps1", "Oct 14 2022  7:00PM", "Oct 14 2022  7:00PM", 7),
                new BucketAppEventLog(19830048, "NewsDriver.ps1", "Oct 14 2022  8:00PM", "Oct 14 2022  8:00PM", 11),
                new BucketAppEventLog(19830187, "RubyDriver.ps1", "Oct 14 2022  8:30PM", "Oct 14 2022  8:35PM", 351),
                new BucketAppEventLog(19830198, "Full Pull", "Oct 14 2022  8:30PM", "Oct 14 2022  8:35PM", 344),
                new BucketAppEventLog(19830433, "GetPersonnelPics.ps1", "Oct 14 2022  9:30PM", "Oct 14 2022  9:30PM", 5),
                new BucketAppEventLog(19830765, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 14 2022 11:00PM", "Oct 15 2022 12:18AM", 4687),
                new BucketAppEventLog(19832221, "NewsDriver.ps1", "Oct 15 2022  6:00AM", "Oct 15 2022  6:01AM", 34),
                new BucketAppEventLog(19832481, "NewsDriver.ps1", "Oct 15 2022  7:00AM", "Oct 15 2022  7:00AM", 7),
                new BucketAppEventLog(19832781, "NewsDriver.ps1", "Oct 15 2022  8:00AM", "Oct 15 2022  8:00AM", 10),
                new BucketAppEventLog(19833017, "NewsDriver.ps1", "Oct 15 2022  9:00AM", "Oct 15 2022  9:00AM", 6),
                new BucketAppEventLog(19833281, "NewsDriver.ps1", "Oct 15 2022 10:00AM", "Oct 15 2022 10:00AM", 7),
                new BucketAppEventLog(19833545, "NewsDriver.ps1", "Oct 15 2022 11:00AM", "Oct 15 2022 11:00AM", 6),
                new BucketAppEventLog(19833839, "NewsDriver.ps1", "Oct 15 2022 12:00PM", "Oct 15 2022 12:00PM", 7),
                new BucketAppEventLog(19834088, "NewsDriver.ps1", "Oct 15 2022  1:00PM", "Oct 15 2022  1:00PM", 6),
                new BucketAppEventLog(19834383, "NewsDriver.ps1", "Oct 15 2022  2:00PM", "Oct 15 2022  2:00PM", 6),
                new BucketAppEventLog(19834644, "NewsDriver.ps1", "Oct 15 2022  3:00PM", "Oct 15 2022  3:00PM", 6),
                new BucketAppEventLog(19834940, "NewsDriver.ps1", "Oct 15 2022  4:00PM", "Oct 15 2022  4:00PM", 14),
                new BucketAppEventLog(19835216, "NewsDriver.ps1", "Oct 15 2022  5:00PM", "Oct 15 2022  5:00PM", 15),
                new BucketAppEventLog(19835446, "NewsDriver.ps1", "Oct 15 2022  5:59PM", "Oct 15 2022  6:00PM", 8),
                new BucketAppEventLog(19835725, "NewsDriver.ps1", "Oct 15 2022  6:59PM", "Oct 15 2022  6:59PM", 6),
                new BucketAppEventLog(19836030, "NewsDriver.ps1", "Oct 15 2022  8:00PM", "Oct 15 2022  8:00PM", 11),
                new BucketAppEventLog(19836161, "RubyDriver.ps1", "Oct 15 2022  8:30PM", "Oct 15 2022  8:36PM", 374),
                new BucketAppEventLog(19836172, "Full Pull", "Oct 15 2022  8:30PM", "Oct 15 2022  8:36PM", 369),
                new BucketAppEventLog(19836387, "GetPersonnelPics.ps1", "Oct 15 2022  9:30PM", "Oct 15 2022  9:30PM", 9),
                new BucketAppEventLog(19836724, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 15 2022 11:00PM", "Oct 16 2022 12:08AM", 4116),
                new BucketAppEventLog(19838184, "NewsDriver.ps1", "Oct 16 2022  6:00AM", "Oct 16 2022  6:00AM", 11),
                new BucketAppEventLog(19838226, "MarketCap.ps1", "Oct 16 2022  6:05AM", "", 0),
                new BucketAppEventLog(19838471, "NewsDriver.ps1", "Oct 16 2022  7:00AM", "Oct 16 2022  7:00AM", 9),
                new BucketAppEventLog(19838761, "NewsDriver.ps1", "Oct 16 2022  8:00AM", "Oct 16 2022  8:00AM", 8),
                new BucketAppEventLog(19839032, "NewsDriver.ps1", "Oct 16 2022  9:00AM", "Oct 16 2022  9:00AM", 8),
                new BucketAppEventLog(19839259, "NewsDriver.ps1", "Oct 16 2022  9:59AM", "Oct 16 2022 10:00AM", 15),
                new BucketAppEventLog(19839584, "NewsDriver.ps1", "Oct 16 2022 11:00AM", "Oct 16 2022 11:00AM", 8),
                new BucketAppEventLog(19839854, "NewsDriver.ps1", "Oct 16 2022 12:00PM", "Oct 16 2022 12:00PM", 7),
                new BucketAppEventLog(19840088, "NewsDriver.ps1", "Oct 16 2022  1:00PM", "Oct 16 2022  1:00PM", 12),
                new BucketAppEventLog(19840402, "NewsDriver.ps1", "Oct 16 2022  2:00PM", "Oct 16 2022  2:00PM", 15),
                new BucketAppEventLog(19840699, "NewsDriver.ps1", "Oct 16 2022  3:05PM", "Oct 16 2022  3:05PM", 6),
                new BucketAppEventLog(19840782, "NewsDriver.ps1", "Oct 16 2022  3:26PM", "Oct 16 2022  3:26PM", 6),
                new BucketAppEventLog(19840981, "NewsDriver.ps1", "Oct 16 2022  4:05PM", "Oct 16 2022  4:05PM", 7),
                new BucketAppEventLog(19841208, "NewsDriver.ps1", "Oct 16 2022  5:00PM", "Oct 16 2022  5:00PM", 21),
                new BucketAppEventLog(19841495, "NewsDriver.ps1", "Oct 16 2022  6:00PM", "Oct 16 2022  6:00PM", 13),
                new BucketAppEventLog(19841789, "NewsDriver.ps1", "Oct 16 2022  7:00PM", "Oct 16 2022  7:00PM", 8),
                new BucketAppEventLog(19842025, "NewsDriver.ps1", "Oct 16 2022  8:00PM", "Oct 16 2022  8:00PM", 11),
                new BucketAppEventLog(19842160, "RubyDriver.ps1", "Oct 16 2022  8:30PM", "Oct 16 2022  8:36PM", 385),
                new BucketAppEventLog(19842166, "Full Pull", "Oct 16 2022  8:30PM", "Oct 16 2022  8:36PM", 380),
                new BucketAppEventLog(19842427, "GetPersonnelPics.ps1", "Oct 16 2022  9:30PM", "Oct 16 2022  9:30PM", 4),
                new BucketAppEventLog(19842743, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 16 2022 11:00PM", "Oct 17 2022 12:13AM", 4355),
                new BucketAppEventLog(19844192, "NewsDriver.ps1", "Oct 17 2022  6:00AM", "Oct 17 2022  6:00AM", 18),
                new BucketAppEventLog(19844489, "NewsDriver.ps1", "Oct 17 2022  7:00AM", "Oct 17 2022  7:00AM", 11),
                new BucketAppEventLog(19844794, "NewsDriver.ps1", "Oct 17 2022  8:00AM", "Oct 17 2022  8:00AM", 9),
                new BucketAppEventLog(19845063, "NewsDriver.ps1", "Oct 17 2022  9:00AM", "Oct 17 2022  9:00AM", 7),
                new BucketAppEventLog(19845301, "NewsDriver.ps1", "Oct 17 2022 10:00AM", "Oct 17 2022 10:00AM", 28),
                new BucketAppEventLog(19845618, "NewsDriver.ps1", "Oct 17 2022 11:00AM", "Oct 17 2022 11:00AM", 9),
                new BucketAppEventLog(19845918, "NewsDriver.ps1", "Oct 17 2022 12:05PM", "Oct 17 2022 12:05PM", 7),
                new BucketAppEventLog(19846144, "NewsDriver.ps1", "Oct 17 2022  1:00PM", "Oct 17 2022  1:00PM", 15),
                new BucketAppEventLog(19846454, "NewsDriver.ps1", "Oct 17 2022  2:00PM", "Oct 17 2022  2:00PM", 10),
                new BucketAppEventLog(19846699, "NewsDriver.ps1", "Oct 17 2022  3:00PM", "Oct 17 2022  3:00PM", 7),
                new BucketAppEventLog(19847011, "NewsDriver.ps1", "Oct 17 2022  4:00PM", "Oct 17 2022  4:00PM", 8),
                new BucketAppEventLog(19847315, "NewsDriver.ps1", "Oct 17 2022  5:05PM", "Oct 17 2022  5:05PM", 6),
                new BucketAppEventLog(19847567, "NewsDriver.ps1", "Oct 17 2022  6:00PM", "Oct 17 2022  6:00PM", 26),
                new BucketAppEventLog(19847828, "NewsDriver.ps1", "Oct 17 2022  7:00PM", "Oct 17 2022  7:00PM", 11),
                new BucketAppEventLog(19848169, "NewsDriver.ps1", "Oct 17 2022  8:05PM", "Oct 17 2022  8:05PM", 7),
                new BucketAppEventLog(19848241, "NewsDriver.ps1", "Oct 17 2022  8:26PM", "Oct 17 2022  8:27PM", 6),
                new BucketAppEventLog(19848276, "RubyDriver.ps1", "Oct 17 2022  8:30PM", "Oct 17 2022  8:35PM", 330),
                new BucketAppEventLog(19848288, "Full Pull", "Oct 17 2022  8:30PM", "Oct 17 2022  8:35PM", 326),
                new BucketAppEventLog(19848527, "GetPersonnelPics.ps1", "Oct 17 2022  9:30PM", "Oct 17 2022  9:30PM", 8),
                new BucketAppEventLog(19848849, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 17 2022 11:00PM", "Oct 18 2022 12:10AM", 4207),
                new BucketAppEventLog(19850384, "NewsDriver.ps1", "Oct 18 2022  6:00AM", "Oct 18 2022  6:00AM", 7),
                new BucketAppEventLog(19850702, "NewsDriver.ps1", "Oct 18 2022  7:00AM", "Oct 18 2022  7:00AM", 13),
                new BucketAppEventLog(19850956, "NewsDriver.ps1", "Oct 18 2022  8:00AM", "Oct 18 2022  8:00AM", 7),
                new BucketAppEventLog(19851263, "NewsDriver.ps1", "Oct 18 2022  9:05AM", "Oct 18 2022  9:05AM", 6),
                new BucketAppEventLog(19851485, "NewsDriver.ps1", "Oct 18 2022 10:00AM", "Oct 18 2022 10:00AM", 9),
                new BucketAppEventLog(19851804, "NewsDriver.ps1", "Oct 18 2022 11:00AM", "Oct 18 2022 11:00AM", 13),
                new BucketAppEventLog(19852029, "NewsDriver.ps1", "Oct 18 2022 12:00PM", "Oct 18 2022 12:00PM", 13),
                new BucketAppEventLog(19852301, "NewsDriver.ps1", "Oct 18 2022  1:00PM", "Oct 18 2022  1:00PM", 7),
                new BucketAppEventLog(19852576, "NewsDriver.ps1", "Oct 18 2022  2:00PM", "Oct 18 2022  2:00PM", 7),
                new BucketAppEventLog(19852858, "NewsDriver.ps1", "Oct 18 2022  3:00PM", "Oct 18 2022  3:00PM", 21),
                new BucketAppEventLog(19853138, "NewsDriver.ps1", "Oct 18 2022  4:00PM", "Oct 18 2022  4:00PM", 7),
                new BucketAppEventLog(19853433, "NewsDriver.ps1", "Oct 18 2022  5:00PM", "Oct 18 2022  5:00PM", 17),
                new BucketAppEventLog(19853729, "NewsDriver.ps1", "Oct 18 2022  6:00PM", "Oct 18 2022  6:00PM", 8),
                new BucketAppEventLog(19853976, "NewsDriver.ps1", "Oct 18 2022  7:00PM", "Oct 18 2022  7:00PM", 7),
                new BucketAppEventLog(19854296, "NewsDriver.ps1", "Oct 18 2022  8:00PM", "Oct 18 2022  8:00PM", 7),
                new BucketAppEventLog(19854406, "RubyDriver.ps1", "Oct 18 2022  8:30PM", "Oct 18 2022  8:36PM", 382),
                new BucketAppEventLog(19854409, "Full Pull", "Oct 18 2022  8:30PM", "Oct 18 2022  8:36PM", 376),
                new BucketAppEventLog(19854643, "GetPersonnelPics.ps1", "Oct 18 2022  9:30PM", "Oct 18 2022  9:30PM", 14),
                new BucketAppEventLog(19854992, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 18 2022 11:00PM", "Oct 19 2022 12:14AM", 4419),
                new BucketAppEventLog(19856534, "NewsDriver.ps1", "Oct 19 2022  6:00AM", "Oct 19 2022  6:00AM", 19),
                new BucketAppEventLog(19856824, "NewsDriver.ps1", "Oct 19 2022  7:00AM", "Oct 19 2022  7:00AM", 13),
                new BucketAppEventLog(19857075, "NewsDriver.ps1", "Oct 19 2022  8:00AM", "Oct 19 2022  8:00AM", 7),
                new BucketAppEventLog(19857358, "NewsDriver.ps1", "Oct 19 2022  9:00AM", "Oct 19 2022  9:00AM", 7),
                new BucketAppEventLog(19857605, "NewsDriver.ps1", "Oct 19 2022 10:00AM", "Oct 19 2022 10:00AM", 7),
                new BucketAppEventLog(19857931, "NewsDriver.ps1", "Oct 19 2022 11:00AM", "Oct 19 2022 11:00AM", 8),
                new BucketAppEventLog(19858203, "NewsDriver.ps1", "Oct 19 2022 12:00PM", "Oct 19 2022 12:00PM", 8),
                new BucketAppEventLog(19858476, "NewsDriver.ps1", "Oct 19 2022  1:00PM", "Oct 19 2022  1:00PM", 8),
                new BucketAppEventLog(19858771, "NewsDriver.ps1", "Oct 19 2022  2:05PM", "Oct 19 2022  2:05PM", 6),
                new BucketAppEventLog(19859001, "NewsDriver.ps1", "Oct 19 2022  3:00PM", "Oct 19 2022  3:00PM", 35),
                new BucketAppEventLog(19859287, "NewsDriver.ps1", "Oct 19 2022  4:00PM", "Oct 19 2022  4:00PM", 7),
                new BucketAppEventLog(19859553, "NewsDriver.ps1", "Oct 19 2022  5:00PM", "Oct 19 2022  5:00PM", 7),
                new BucketAppEventLog(19859824, "NewsDriver.ps1", "Oct 19 2022  6:00PM", "Oct 19 2022  6:00PM", 7),
                new BucketAppEventLog(19860171, "NewsDriver.ps1", "Oct 19 2022  7:05PM", "Oct 19 2022  7:05PM", 9),
                new BucketAppEventLog(19860429, "NewsDriver.ps1", "Oct 19 2022  8:00PM", "Oct 19 2022  8:00PM", 16),
                new BucketAppEventLog(19860569, "RubyDriver.ps1", "Oct 19 2022  8:30PM", "Oct 19 2022  8:36PM", 374),
                new BucketAppEventLog(19860573, "Full Pull", "Oct 19 2022  8:30PM", "Oct 19 2022  8:36PM", 370),
                new BucketAppEventLog(19860809, "GetPersonnelPics.ps1", "Oct 19 2022  9:30PM", "Oct 19 2022  9:30PM", 8),
                new BucketAppEventLog(19861135, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 19 2022 11:00PM", "Oct 22 2022 12:09AM", 176964),
                new BucketAppEventLog(19862597, "NewsDriver.ps1", "Oct 20 2022  6:00AM", "Oct 20 2022  6:00AM", 10),
                new BucketAppEventLog(19862906, "NewsDriver.ps1", "Oct 20 2022  7:00AM", "Oct 20 2022  7:00AM", 22),
                new BucketAppEventLog(19863203, "NewsDriver.ps1", "Oct 20 2022  8:00AM", "Oct 20 2022  8:00AM", 10),
                new BucketAppEventLog(19863439, "NewsDriver.ps1", "Oct 20 2022  9:00AM", "Oct 20 2022  9:00AM", 9),
                new BucketAppEventLog(19863737, "NewsDriver.ps1", "Oct 20 2022 10:00AM", "Oct 20 2022 10:00AM", 33),
                new BucketAppEventLog(19864025, "NewsDriver.ps1", "Oct 20 2022 11:00AM", "Oct 20 2022 11:00AM", 11),
                new BucketAppEventLog(19864296, "NewsDriver.ps1", "Oct 20 2022 12:00PM", "Oct 20 2022 12:00PM", 20),
                new BucketAppEventLog(19864551, "NewsDriver.ps1", "Oct 20 2022  1:00PM", "Oct 20 2022  1:00PM", 17),
                new BucketAppEventLog(19864835, "NewsDriver.ps1", "Oct 20 2022  2:00PM", "Oct 20 2022  2:00PM", 15),
                new BucketAppEventLog(19865116, "NewsDriver.ps1", "Oct 20 2022  3:00PM", "Oct 20 2022  3:00PM", 13),
                new BucketAppEventLog(19865410, "NewsDriver.ps1", "Oct 20 2022  4:00PM", "Oct 20 2022  4:00PM", 15),
                new BucketAppEventLog(19865650, "NewsDriver.ps1", "Oct 20 2022  5:00PM", "Oct 20 2022  5:00PM", 29),
                new BucketAppEventLog(19865928, "NewsDriver.ps1", "Oct 20 2022  6:00PM", "Oct 20 2022  6:00PM", 22),
                new BucketAppEventLog(19866284, "NewsDriver.ps1", "Oct 20 2022  7:05PM", "Oct 20 2022  7:05PM", 8),
                new BucketAppEventLog(19866542, "NewsDriver.ps1", "Oct 20 2022  8:00PM", "Oct 20 2022  8:00PM", 12),
                new BucketAppEventLog(19866642, "RubyDriver.ps1", "Oct 20 2022  8:30PM", "Oct 20 2022  8:37PM", 420),
                new BucketAppEventLog(19866645, "Full Pull", "Oct 20 2022  8:30PM", "Oct 20 2022  8:37PM", 414),
                new BucketAppEventLog(19866886, "GetPersonnelPics.ps1", "Oct 20 2022  9:30PM", "Oct 20 2022  9:30PM", 8),
                new BucketAppEventLog(19867240, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 20 2022 11:00PM", "Oct 22 2022 12:09AM", 90566),
                new BucketAppEventLog(19868790, "NewsDriver.ps1", "Oct 21 2022  6:00AM", "Oct 21 2022  6:01AM", 35),
                new BucketAppEventLog(19869132, "NewsDriver.ps1", "Oct 21 2022  7:05AM", "Oct 21 2022  7:05AM", 7),
                new BucketAppEventLog(19869347, "NewsDriver.ps1", "Oct 21 2022  8:00AM", "Oct 21 2022  8:00AM", 10),
                new BucketAppEventLog(19869634, "NewsDriver.ps1", "Oct 21 2022  9:00AM", "Oct 21 2022  9:00AM", 13),
                new BucketAppEventLog(19869939, "NewsDriver.ps1", "Oct 21 2022 10:00AM", "Oct 21 2022 10:00AM", 15),
                new BucketAppEventLog(19870228, "NewsDriver.ps1", "Oct 21 2022 11:00AM", "Oct 21 2022 11:00AM", 8),
                new BucketAppEventLog(19870470, "NewsDriver.ps1", "Oct 21 2022 12:00PM", "Oct 21 2022 12:00PM", 16),
                new BucketAppEventLog(19870784, "NewsDriver.ps1", "Oct 21 2022  1:00PM", "Oct 21 2022  1:00PM", 8),
                new BucketAppEventLog(19871026, "NewsDriver.ps1", "Oct 21 2022  2:00PM", "Oct 21 2022  2:00PM", 13),
                new BucketAppEventLog(19871353, "NewsDriver.ps1", "Oct 21 2022  3:05PM", "Oct 21 2022  3:05PM", 8),
                new BucketAppEventLog(19871607, "NewsDriver.ps1", "Oct 21 2022  4:00PM", "Oct 21 2022  4:00PM", 10),
                new BucketAppEventLog(19871915, "NewsDriver.ps1", "Oct 21 2022  5:05PM", "Oct 21 2022  5:05PM", 7),
                new BucketAppEventLog(19872171, "NewsDriver.ps1", "Oct 21 2022  6:00PM", "Oct 21 2022  6:00PM", 13),
                new BucketAppEventLog(19872446, "NewsDriver.ps1", "Oct 21 2022  7:00PM", "Oct 21 2022  7:00PM", 17),
                new BucketAppEventLog(19872715, "NewsDriver.ps1", "Oct 21 2022  8:00PM", "Oct 21 2022  8:00PM", 11),
                new BucketAppEventLog(19872866, "RubyDriver.ps1", "Oct 21 2022  8:30PM", "Oct 21 2022  8:36PM", 355),
                new BucketAppEventLog(19872873, "Full Pull", "Oct 21 2022  8:30PM", "Oct 21 2022  8:36PM", 348),
                new BucketAppEventLog(19873140, "GetPersonnelPics.ps1", "Oct 21 2022  9:30PM", "Oct 21 2022  9:30PM", 3),
                new BucketAppEventLog(19873447, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 21 2022 11:00PM", "Oct 22 2022 12:09AM", 4179),
                new BucketAppEventLog(19874993, "NewsDriver.ps1", "Oct 22 2022  6:00AM", "Oct 22 2022  6:01AM", 88),
                new BucketAppEventLog(19875311, "NewsDriver.ps1", "Oct 22 2022  7:00AM", "Oct 22 2022  7:00AM", 22),
                new BucketAppEventLog(19875624, "NewsDriver.ps1", "Oct 22 2022  8:00AM", "Oct 22 2022  8:00AM", 9),
                new BucketAppEventLog(19875868, "NewsDriver.ps1", "Oct 22 2022  9:00AM", "Oct 22 2022  9:00AM", 12),
                new BucketAppEventLog(19876153, "NewsDriver.ps1", "Oct 22 2022 10:00AM", "Oct 22 2022 10:00AM", 10),
                new BucketAppEventLog(19876483, "NewsDriver.ps1", "Oct 22 2022 11:05AM", "Oct 22 2022 11:05AM", 8),
                new BucketAppEventLog(19876708, "NewsDriver.ps1", "Oct 22 2022 12:00PM", "Oct 22 2022 12:00PM", 14),
                new BucketAppEventLog(19877048, "NewsDriver.ps1", "Oct 22 2022  1:05PM", "Oct 22 2022  1:05PM", 7),
                new BucketAppEventLog(19877478, "NewsDriver.ps1", "Oct 22 2022  3:00PM", "Oct 22 2022  3:00PM", 18),
                new BucketAppEventLog(19877774, "NewsDriver.ps1", "Oct 22 2022  4:00PM", "Oct 22 2022  4:00PM", 11),
                new BucketAppEventLog(19878069, "NewsDriver.ps1", "Oct 22 2022  5:00PM", "Oct 22 2022  5:00PM", 13),
                new BucketAppEventLog(19878316, "NewsDriver.ps1", "Oct 22 2022  6:00PM", "Oct 22 2022  6:00PM", 13),
                new BucketAppEventLog(19878628, "NewsDriver.ps1", "Oct 22 2022  7:00PM", "Oct 22 2022  7:00PM", 9),
                new BucketAppEventLog(19878949, "NewsDriver.ps1", "Oct 22 2022  8:00PM", "Oct 22 2022  8:00PM", 9),
                new BucketAppEventLog(19879034, "RubyDriver.ps1", "Oct 22 2022  8:30PM", "Oct 22 2022  8:35PM", 324),
                new BucketAppEventLog(19879043, "Full Pull", "Oct 22 2022  8:30PM", "Oct 22 2022  8:35PM", 320),
                new BucketAppEventLog(19879568, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 22 2022 11:00PM", "Oct 23 2022 12:02AM", 3727),
                new BucketAppEventLog(19881605, "MarketCap.ps1", "Oct 23 2022  6:00AM", "", 0),
                new BucketAppEventLog(19885542, "RubyDriver.ps1", "Oct 23 2022  8:28PM", "Oct 23 2022  8:32PM", 231),
                new BucketAppEventLog(19885548, "Full Pull", "Oct 23 2022  8:28PM", "Oct 23 2022  8:32PM", 226),
                new BucketAppEventLog(19885777, "GetPersonnelPics.ps1", "Oct 23 2022  9:28PM", "Oct 23 2022  9:28PM", 3),
                new BucketAppEventLog(19886118, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 23 2022 11:00PM", "Oct 24 2022 12:09AM", 4180),
                new BucketAppEventLog(19891683, "RubyDriver.ps1", "Oct 24 2022  8:30PM", "Oct 24 2022  8:33PM", 186),
                new BucketAppEventLog(19891696, "Full Pull", "Oct 24 2022  8:30PM", "Oct 24 2022  8:33PM", 180),
                new BucketAppEventLog(19891921, "GetPersonnelPics.ps1", "Oct 24 2022  9:30PM", "Oct 24 2022  9:30PM", 6),
                new BucketAppEventLog(19892264, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 24 2022 11:00PM", "Oct 25 2022 12:09AM", 4148),
                new BucketAppEventLog(19897852, "RubyDriver.ps1", "Oct 25 2022  8:30PM", "Oct 25 2022  8:35PM", 337),
                new BucketAppEventLog(19897868, "Full Pull", "Oct 25 2022  8:30PM", "Oct 25 2022  8:35PM", 330),
                new BucketAppEventLog(19898108, "GetPersonnelPics.ps1", "Oct 25 2022  9:30PM", "Oct 25 2022  9:30PM", 5),
                new BucketAppEventLog(19898435, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 25 2022 11:00PM", "Oct 26 2022 12:12AM", 4328),
                new BucketAppEventLog(19904128, "RubyDriver.ps1", "Oct 26 2022  8:30PM", "Oct 26 2022  8:36PM", 371),
                new BucketAppEventLog(19904137, "Full Pull", "Oct 26 2022  8:30PM", "Oct 26 2022  8:36PM", 365),
                new BucketAppEventLog(19904358, "GetPersonnelPics.ps1", "Oct 26 2022  9:30PM", "Oct 26 2022  9:30PM", 5),
                new BucketAppEventLog(19904680, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 26 2022 11:00PM", "Oct 27 2022 12:18AM", 4717),
                new BucketAppEventLog(19910291, "RubyDriver.ps1", "Oct 27 2022  8:30PM", "Oct 27 2022  8:38PM", 485),
                new BucketAppEventLog(19910307, "Full Pull", "Oct 27 2022  8:30PM", "Oct 27 2022  8:38PM", 477),
                new BucketAppEventLog(19910540, "GetPersonnelPics.ps1", "Oct 27 2022  9:30PM", "Oct 27 2022  9:30PM", 9),
                new BucketAppEventLog(19910885, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 27 2022 11:00PM", "Oct 29 2022 12:17AM", 91030),
                new BucketAppEventLog(19916501, "RubyDriver.ps1", "Oct 28 2022  8:30PM", "Oct 28 2022  8:33PM", 216),
                new BucketAppEventLog(19916515, "Full Pull", "Oct 28 2022  8:30PM", "Oct 28 2022  8:33PM", 211),
                new BucketAppEventLog(19916742, "GetPersonnelPics.ps1", "Oct 28 2022  9:30PM", "Oct 28 2022  9:30PM", 6),
                new BucketAppEventLog(19917082, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 28 2022 11:00PM", "Oct 29 2022 12:17AM", 4631),
                new BucketAppEventLog(19922681, "RubyDriver.ps1", "Oct 29 2022  8:30PM", "Oct 29 2022  8:36PM", 377),
                new BucketAppEventLog(19922687, "Full Pull", "Oct 29 2022  8:30PM", "Oct 29 2022  8:36PM", 372),
                new BucketAppEventLog(19922932, "GetPersonnelPics.ps1", "Oct 29 2022  9:30PM", "Oct 29 2022  9:30PM", 3),
                new BucketAppEventLog(19923269, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 29 2022 11:00PM", "Oct 30 2022 12:16AM", 4598),
                new BucketAppEventLog(19924833, "MarketCap.ps1", "Oct 30 2022  6:00AM", "", 0),
                new BucketAppEventLog(19928869, "RubyDriver.ps1", "Oct 30 2022  8:30PM", "Oct 30 2022  8:36PM", 388),
                new BucketAppEventLog(19928894, "Full Pull", "Oct 30 2022  8:30PM", "Oct 30 2022  8:36PM", 380),
                new BucketAppEventLog(19929135, "GetPersonnelPics.ps1", "Oct 30 2022  9:30PM", "Oct 30 2022  9:30PM", 4),
                new BucketAppEventLog(19929455, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 30 2022 11:00PM", "Oct 31 2022 12:18AM", 4688),
                new BucketAppEventLog(19931485, "RubyDriver.ps1", "Oct 31 2022  7:31AM", "Oct 31 2022  7:32AM", 29),
                new BucketAppEventLog(19931486, "Full Pull", "Oct 31 2022  7:31AM", "Oct 31 2022  7:32AM", 27),
                new BucketAppEventLog(19935076, "RubyDriver.ps1", "Oct 31 2022  8:30PM", "Oct 31 2022  8:36PM", 375),
                new BucketAppEventLog(19935100, "Full Pull", "Oct 31 2022  8:30PM", "Oct 31 2022  8:36PM", 369),
                new BucketAppEventLog(19935340, "GetPersonnelPics.ps1", "Oct 31 2022  9:30PM", "Oct 31 2022  9:30PM", 7),
                new BucketAppEventLog(19935701, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Oct 31 2022 11:00PM", "Nov  1 2022 12:15AM", 4480),
                new BucketAppEventLog(19941315, "RubyDriver.ps1", "Nov  1 2022  8:30PM", "Nov  1 2022  8:37PM", 414),
                new BucketAppEventLog(19941324, "Full Pull", "Nov  1 2022  8:30PM", "Nov  1 2022  8:37PM", 409),
                new BucketAppEventLog(19941552, "GetPersonnelPics.ps1", "Nov  1 2022  9:30PM", "Nov  1 2022  9:30PM", 6),
                new BucketAppEventLog(19941877, "\\Scheduled\\Foundation\\FoundationSync.ps1", "Nov  1 2022 11:00PM", "", 0),            };
            #endregion

            return await Task.FromResult(AppEventLogs);
        }


        #region UnUsed
        /*



        public void Reset(Type entityType) => Context.ChangeTracker.Entries()
            .Where(e => e.Entity != null && e.Entity.GetType() == entityType).ToList()
            .ForEach(e => e.State = EntityState.Detached);

        #region Expenses
        partial void OnExpensesRead(ref IQueryable<Expense> items);

        public async Task<IQueryable<Expense>> GetExpenses(Query query = null)
        {
            var items = Context.Expenses.AsQueryable();
            
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnExpensesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnExpenseGet(Expense item);

        public async Task<Expense> GetExpenseByGLJERowUno(string gljeRowUno)
        {
            var items = Context.Expenses
                              .AsNoTracking()
                              .Where(i => i.GLJERowUno == gljeRowUno);

            var itemToReturn = items.FirstOrDefault();

            OnExpenseGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnExpenseUpdated(Models.ExpenseReclassDb.Expense item);
        partial void OnAfterExpenseUpdated(Models.ExpenseReclassDb.Expense item);

        public void UpdateExpense(Expense expense, string loggedInUserName)
        {
            OnExpenseUpdated(expense);

            var itemToUpdate = Context.Expenses
                              .Where(i => i.GLJERowUno == expense.GLJERowUno)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            expense.UpdatedTime = DateTime.Now;
            expense.UpdatedBy = loggedInUserName;

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(expense);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterExpenseUpdated(expense);
        }
        #endregion

        #region reclasses
        public async Task ExportReclassesToExcel(string reclassesInstGuid, Query query = null, string fileName = null, string altHeader = null, bool isPreview = true)
        {
           navigationManager.NavigateTo(query != null ? query.ToUrl($"export/expensereclassdb/reclasses/excel(reclassesInstGuid='{reclassesInstGuid}',fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}',altHeader='{altHeader}',isPreview='{isPreview}')") 
                : $"export/expensereclassdb/reclasses/excel(reclassesInstGuid='{reclassesInstGuid}',fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}',altHeader='{altHeader}',isPreview='{isPreview}')", true);
        }
        
        // not used currently
        public async Task ExportReclassesToCSV(string reclassesInstGuid, Query query = null, string fileName = null, string altHeader = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/expensereclassdb/reclasses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}',altHeader='{altHeader}',reclassesInstGuid='{reclassesInstGuid}')") 
                : $"export/expensereclassdb/reclasses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}',altHeader='{altHeader}',reclassesInstGuid='{reclassesInstGuid}')", true);
        }

        partial void OnReclassesRead(ref IQueryable<Reclass> items);

        public async Task<IQueryable<Reclass>> GetReclasses(Query query = null)
        {
            var items = Context.Reclasses.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnReclassesRead(ref items);

            return await Task.FromResult(items);
        }

        public void ReloadExportedReclasses(string exportFileName)
        {   
            foreach (var reclass in Context.Reclasses.Where(x => x.ExportFileName == exportFileName))
            {
                Context.Entry(reclass).State = EntityState.Detached;
            }
        }

        public bool IsExportFileNameUnique(string newFileName)
        {
            return (Context.Reclasses.Where(x => x.ExportFileName == newFileName).Count() == 0);
        }

        public string GetPreviousExportFileName()
        {
           return Context.Reclasses.OrderByDescending(x => x.ExportedTime).FirstOrDefault().ExportFileName;
        }  

        partial void OnReclassCreated(Reclass item);
        partial void OnAfterReclassCreated(Reclass item);

        public void CreateReclass(Reclass reclass, string loggedInUserID)
        {
            OnReclassCreated(reclass);

            var existingItem = Context.Reclasses
                              .Where(i => i.GLJERowUno == reclass.GLJERowUno && i.Sequence == reclass.Sequence)
                              .FirstOrDefault();

            if (existingItem != null)
            {
                throw new Exception("Item already exists");
            }

            try
            {
                reclass.CreatedTime = DateTime.Now;
                if (string.IsNullOrWhiteSpace(reclass.CreatedBy))
                    reclass.CreatedBy = loggedInUserID;

                Context.Reclasses.Add(reclass);
                Context.SaveChanges();
                GlobalsService.ReclassesChangeTime = DateTime.Now; // inform all app instances to reload
            }
            catch
            {
                Context.Entry(reclass).State = EntityState.Detached;
                throw;
            }

            OnAfterReclassCreated(reclass);
        }

        partial void OnReclassDeleted(Reclass item);
        partial void OnAfterReclassDeleted(Reclass item);

        public async Task DeleteReclass(string gljeRowUno, int? sequence) { }

        // this doesn't work
        public void DeleteReclass(string gljeRowUno, int? sequence, string loggedInUserID)
        {
            var itemToDelete = Context.Reclasses
                              .Where(i => i.GLJERowUno == gljeRowUno && i.Sequence == sequence)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer exists");
            }

            OnReclassDeleted(itemToDelete);

            var entryToUpdate = Context.Entry(itemToDelete);
            int newSequence = Context.Reclasses.Where(i => i.GLJERowUno == gljeRowUno).Min(x => x.Sequence) - 2;
            itemToDelete.Sequence = newSequence;
            itemToDelete.IsDeleted = true;
            itemToDelete.UpdatedTime = DateTime.Now;
            itemToDelete.UpdatedBy = loggedInUserID;
            
            entryToUpdate.State = EntityState.Modified;
            foreach (var reclass in Context.Reclasses.Where(i => i.GLJERowUno == gljeRowUno && i.Sequence != newSequence))
            {
                entryToUpdate = Context.Entry(reclass);
                reclass.Sequence = reclass.Sequence - 1;
                entryToUpdate.State = EntityState.Modified;
            }

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterReclassDeleted(itemToDelete);
        }

        partial void OnReclassGet(Reclass item);

        public async Task<Reclass> GetReclassByGLJERowUnoAndSequence(string gljeRowUno, int? sequence)
        {
            var items = Context.Reclasses
                              .AsNoTracking()
                              .Where(i => i.GLJERowUno == gljeRowUno && i.Sequence == sequence);

            var itemToReturn = items.FirstOrDefault();

            OnReclassGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Reclass> CancelReclassChanges(Reclass item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
                entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
                entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnReclassUpdated(Reclass item);
        partial void OnAfterReclassUpdated(Reclass item);

        public void UpdateReclass(Reclass reclass, string loggedInUserID)
        {
            OnReclassUpdated(reclass);

            var itemToUpdate = Context.Reclasses
                              .Where(i => i.GLJERowUno == reclass.GLJERowUno && i.Sequence == reclass.Sequence)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer exists");
            }

            reclass.UpdatedTime = DateTime.Now;
            reclass.UpdatedBy = loggedInUserID;

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(reclass);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            GlobalsService.ReclassesChangeTime = DateTime.Now; // inform all app instances to reload
        }
        #endregion

        #region user settings
        partial void OnUserSettingCreated(UserSetting item);
        partial void OnAfterUserSettingCreated(UserSetting item);

        public async Task CreateUserSetting(UserSetting userSetting)
        {
            OnUserSettingCreated(userSetting);

            var existingItem = Context.UserSettings
                              .Where(i => i.UserName == userSetting.UserName && i.Key == userSetting.Key)
                              .FirstOrDefault();

            if (existingItem != null)
                throw new Exception("Item already exists");

            try
            {
                Context.UserSettings.Add(userSetting);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(userSetting).State = EntityState.Detached;
                throw;
            }

            OnAfterUserSettingCreated(userSetting);
        }

        partial void OnUserSettingDeleted(UserSetting item);
        partial void OnAfterUserSettingDeleted(UserSetting item);

        public async Task DeleteUserSetting(string userName, string key)
        {
            var itemToDelete = Context.UserSettings
                              .Where(i => i.UserName == userName && i.Key == key)
                              .FirstOrDefault();

            if (itemToDelete == null)
                throw new Exception("Item no longer exists");

            OnUserSettingDeleted(itemToDelete);

            Context.UserSettings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterUserSettingDeleted(itemToDelete);
        }

        partial void OnUserSettingGet(UserSetting item);

        public UserSetting GetUserSettingByUserNameAndKey(string userName, string key)
        {
            var items = Context.UserSettings
                              .AsNoTracking()
                              .Where(i => i.UserName == userName && i.Key == key);

            var itemToReturn = items.FirstOrDefault();

            OnUserSettingGet(itemToReturn);

            return itemToReturn;
        }

        public IEnumerable<UserSetting> GetUserSettings(string userName)
        {
            return Context.UserSettings
                              .AsNoTracking()
                              .Where(i => i.UserName == userName);
        }

        partial void OnUserSettingUpdated(UserSetting item);
        partial void OnAfterUserSettingUpdated(UserSetting item);

        public async Task UpdateUserSetting(string userName, string key, string value)
        {
            var userSetting = new UserSetting() { UserName = userName, Key = key, Value = value };

            var itemToUpdate = Context.UserSettings
                              .Where(i => i.UserName == userName && i.Key == key)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                await CreateUserSetting(userSetting);
                return;
            }

            if (itemToUpdate.Value == value) return;

            OnUserSettingUpdated(userSetting);

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(userSetting);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();

            OnAfterUserSettingUpdated(userSetting);
        }

        public async Task SyncUserSettings(string userName, IDictionary<string, string> userSettings)
        {
            foreach (string key in userSettings.Keys)
            {
                await UpdateUserSetting(userName, key, userSettings[key]);
            }
        }
        #endregion

        #region Dapper extensions
        public IEnumerable<string> GetPeriods(string tableName)
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            if (tableName.ToUpper() == "EXPENSERECLASS") { tableName += " WHERE IsDeleted = 0"; }

            var command = new CommandDefinition(
                $"SELECT DISTINCT TOP 25 CAST([Period] AS VARCHAR) AS Period FROM {tableName} ORDER BY [Period] DESC;", // go back 2 years
                null,
                null,
                commandTimeout
            );

            return connection.Query<string>(command);
        }

        public IEnumerable<Reclass> GetReclassSequence(string gljeRowUno)
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            var command = new CommandDefinition(
                @"SELECT GLJERowUno, Sequence, Period, ChromeRiverId, AccountCode, AccountName, OfficeCode, OfficeName, DeptCode, DeptName, EmployeeCode, EmployeeName, JournalAmount,
                        [Description], ProjectCode, ExportFileName, ExportedBy, ExportedTime, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime--, CAST(NULL AS VARCHAR(20)) AS InUseBy, CAST(NULL AS DateTime) AS InUseSince
                    FROM ExpenseReclass WHERE GLJERowUno = @GLJERowUno AND IsDeleted = 0
                UNION ALL
                SELECT GLJERowUno, CAST(0 AS INT), Period, ChromeRiverId, AccountCode, AccountName, OfficeCode, OfficeName, DeptCode, DeptName, EmployeeCode, EmployeeName, JournalAmount,
                        [Description], ProjectCode, NULL, NULL, NULL, NULL, NULL, NULL, NULL--, InUseBy, InUseSince
                    FROM Expense WHERE GLJERowUno = @GLJERowUno
                ORDER BY Sequence;",
                new
                {
                    GLJERowUno = gljeRowUno
                },
                null,
                commandTimeout
            );

            return connection.Query<Reclass>(command);
        }

        public async Task DeleteReclassSequence(string gljeRowUno, int sequence, string loggedInUserID)
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            var command = new CommandDefinition(
                @"UPDATE R SET R.IsDeleted = 1, R.Sequence = (SELECT MIN(Sequence) - 2 FROM ExpenseReclass WHERE GLJERowUno = R.GLJERowUno), 
                    R.UpdatedTime = GETDATE(), R.UpdatedBy = @UpdatedBy FROM ExpenseReclass R WHERE R.GLJERowUno = @GLJERowUno AND R.Sequence = @Sequence;
                UPDATE ExpenseReclass SET Sequence = Sequence - 1 WHERE GLJERowUno = @GLJERowUno AND Sequence > @Sequence;",
                new
                {
                    UpdatedBy = loggedInUserID,
                    GLJERowUno = gljeRowUno,
                    Sequence = sequence
                },
                null,
                commandTimeout
            );

            await connection.ExecuteAsync(command);

            GlobalsService.ReclassesChangeTime = DateTime.Now; // inform all app instances to reload

            foreach (var reclass in Context.Reclasses.Where(i => i.GLJERowUno == gljeRowUno))
            {
                var entryToUpdate = Context.Entry(reclass);
                entryToUpdate.State = EntityState.Detached;
            }
        }

        public async Task<int> UpdateForFileExport(IQueryable<Reclass> exportedReclasses, string exportFileName, string loggedInUserName)
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            // build list of combined keys 
            string keys = string.Join(',', exportedReclasses.Select(x => $"'{x.GetType().GetProperty("GLJERowUno").GetValue(x)}_{x.GetType().GetProperty("Sequence").GetValue(x)}'"));

            var command = new CommandDefinition(
                $@"UPDATE ExpenseReclass SET ExportFileName = @ExportFileName, ExportedBy = @ExportedBy, ExportedTime = GETDATE() 
                FROM ExpenseReclass WHERE GLJERowUno + '_' + CAST(Sequence AS VARCHAR) IN ({keys});",
                new
                {
                    ExportFileName = exportFileName,
                    ExportedBy = loggedInUserName
                },
                null,
                commandTimeout
            );

            int result = await connection.ExecuteAsync(command);
            GlobalsService.ReclassesChangeTime = DateTime.Now; // inform all app instances to reload
            return result;
        }

        public async Task<int> UndoPreviousExport(string loggedInUserID)
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            var command = new CommandDefinition(
                $@"UPDATE ExpenseReclass SET ExportFileName = null, ExportedBy = null, ExportedTime = null, UpdatedBy = @UpdatedBy, UpdatedTime = GETDATE() 
                FROM ExpenseReclass R WHERE ExportedTime = (SELECT MAX(ExportedTime) FROM ExpenseReclass);",
                new
                {
                    UpdatedBy = loggedInUserID
                },
                null,
                commandTimeout);

            int result = await connection.ExecuteAsync(command);
            GlobalsService.ReclassesChangeTime = DateTime.Now; // inform all app instances to reload
            return result;
        }

        public void InsertErrorLog(string summary, string detail, string loggedInUserName)
        {
            var connection = new SqlConnection(GlobalsService.ConnectionStrings["ConnectionStringExpenseReclass"].ConnectionString);
            var commandTimeout = int.Parse(config["CommandTimeout"]);

            var command = new CommandDefinition(
                "INSERT INTO ErrorLog (Summary, Detail, [User], CreatedTime) VALUES (@Summary, @Detail, @User, GETDATE());",
                new
                {
                    Summary = summary,
                    Detail = detail,
                    User = loggedInUserName
                },
                null,
                commandTimeout
            );

            connection.Execute(command);
        }

        public string GetExpenseInUse(string gljeRowUno)
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            var command = new CommandDefinition(
                "SELECT InUseBy FROM Expense WHERE GLJERowUno = @GLJERowUno AND DATEDIFF(DAY, InUseSince, GETDATE()) < 3;", // hold for 3 days
                new
                {
                    GLJERowUno = gljeRowUno
                },
                null,
                commandTimeout
            );

            return (string)connection.ExecuteScalar(command);
        }

        public void SetExpenseInUse(string gljeRowUno, string loggedInUserName)
        {
            if (string.IsNullOrWhiteSpace(loggedInUserName))
                return;

            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            var command = new CommandDefinition(
                "UPDATE Expense SET InUseBy = @User, InUseSince = GETDATE() WHERE GLJERowUno = @GLJERowUno;",
                new
                {
                    GLJERowUno = gljeRowUno,
                    User = loggedInUserName
                },
                null,
                commandTimeout
            );

            connection.Execute(command);
        }

        public void ClearExpenseInUse(string gljeRowUno, string loggedInUserName)
        {
            if (string.IsNullOrWhiteSpace(loggedInUserName))
                return;

            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            var command = new CommandDefinition(
                "UPDATE Expense SET InUseBy = NULL, InUseSince = NULL WHERE GLJERowUno = @GLJERowUno OR InUseBy = @User;",
                new
                {
                    GLJERowUno = gljeRowUno,
                    User = loggedInUserName
                },
                null,
                commandTimeout
            );

            connection.Execute(command);
        }

        public IEnumerable<LineItem> GetLineItems()
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            var command = new CommandDefinition(
                "SELECT LineItemId, [Description], DeptCode FROM LineItem WHERE [Group] = @LineItemGroup ORDER BY [Description];",
                new
                {
                    LineItemGroup = config["LineItemGroup"]
                },
                null,
                commandTimeout
            );

            return connection.Query<LineItem>(command);
        }
        #endregion

        */
        #endregion
    }
}
