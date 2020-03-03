using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static List<Calendar> listCalendars = new List<Calendar>()
        {
            new Calendar()
            {
                ID = 1,
                Title = "Chủ trì giao ban TT Tỉnh ủy",
                Date = new DateTime(2020, 3, 2),
                FromTime = new TimeSpan(8, 0, 0),
                ToTime = new TimeSpan(10, 0, 0),
                LeaderID = 1
            },
            new Calendar()
            {
                ID = 2,
                Title = "Chủ trì giao ban TT Tỉnh ủy",
                Date = new DateTime(2020, 3, 2),
                FromTime = new TimeSpan(8, 0, 0),
                ToTime = new TimeSpan(10, 0, 0),
                LeaderID = 2
            },
            new Calendar()
            {
                ID = 3,
                Title = "Chủ trì giao ban TT Tỉnh ủy",
                Date = new DateTime(2020, 3, 2),
                FromTime = new TimeSpan(8, 0, 0),
                ToTime = new TimeSpan(10, 0, 0),
                LeaderID = 3
            },
            new Calendar()
            {
                ID = 4,
                Title = "Chủ trì giao ban TT Tỉnh ủy",
                Date = new DateTime(2020, 3, 2),
                FromTime = new TimeSpan(8, 0, 0),
                ToTime = new TimeSpan(10, 0, 0),
                LeaderID = 1
            },
             new Calendar()
            {
                ID = 5,
                Title = "Chủ trì giao ban TT Tỉnh ủy",
                Date = new DateTime(2020, 3, 2),
                FromTime = new TimeSpan(8, 0, 0),
                ToTime = new TimeSpan(10, 0, 0),
                LeaderID = 2
            },
              new Calendar()
            {
                ID = 6,
                Title = "Chủ trì giao ban TT Tỉnh ủy",
                Date = new DateTime(2020, 3, 3),
                FromTime = new TimeSpan(8, 0, 0),
                ToTime = new TimeSpan(10, 0, 0),
                LeaderID = 2
            },
        };



        static void Main(string[] args)
        {
           
            Console.WriteLine(RenderHTML(listCalendars, new DateTime(2020, 3, 2)));
            Console.ReadLine();
        }


        public static string RenderHTML(List<Calendar> calendars, DateTime firstDate)
        {
            var html = @"<tr class='head'>
                                <td rowspan = '2' style = 'width: 10%' > Ngày <br> Tháng <br> Năm </td>
                                <td colspan = '2' style = 'width: 30%'> Đ / c Nguyễn Văn Vịnh<br> Bí thư Tỉnh ủy - Chủ tịch HĐND</td>
                                <td colspan = '2' style = 'width: 30%'> Đ / c Vũ Xuân Cường<br> Phó Chủ tịch HĐND </td>
                                <td colspan = '2' style = 'width: 30%'> Đ / c Giàng Mạnh Nhà<br> Phó Chủ tịch HĐND </td>
                            </tr>
                            <tr class='head'>
                                <td style = 'width: 18%' > Thời gian/ Nội dung họp/ Địa điểm</td>
                                <td style = 'width: 12%' > LĐ và CV tham dự</td>
                                <td style = 'width: 18%' > Thời gian/ Nội dung họp/ Địa điểm</td>
                                <td style = 'width: 12%' > LĐ và CV tham dự</td>
                                <td style = 'width: 18%' > Thời gian/ Nội dung họp/ Địa điểm</td>
                                <td style = 'width: 12%' > LĐ và CV tham dự</td>
                            </tr>";


            

            for(int i = 0; i < 7; i++)
            {
                var line = calendars.Where(x => x.Date == firstDate).ToList();
                var lineCount = line.Count();

                var loop = Math.Ceiling((double)lineCount / 3);

                var index = 0;
                for(var j = 0; j < loop; j++)
                {
                    var htmlTemp = "";
                    int dem = 0;
                    var sangChieu = "";
                    if (j % 2 == 0) sangChieu = "sang";
                    else sangChieu = "chieu";
                    for (var k = index; k < lineCount; k++)
                    {
                        var countRowSpan = (int)loop / line.Where(x => x.LeaderID == line[k].LeaderID).Count();
                        dem++;
                        if (k == 0)
                        {
                            htmlTemp += @"<td class='day' rowspan='" + loop + @"'>
                                    <span style = 'color:'>
                                         Thứ hai <br>
                                         02 / 03 / 2020
                                     </span>
                                     <br>
                                     <span class='holiday-title'>
                                    </span>
                                </td>";
                        }
                        htmlTemp += @"<td rowspan = '"+ countRowSpan + @"' class='info-cell "+sangChieu+ @"'>
                                        <ul class='list-info'>
                                            <li class='time'>08:00</li>
                                            <li class='address' style='white-space: pre-wrap;'>Phòng họp BTV Tỉnh ủy</li>
                                            <li class='info' style='white-space: pre-wrap;'>Chủ trì giao ban TT Tỉnh ủy</li>
                                        </ul>
                                    </td>
                                     <td rowspan = '"+ countRowSpan + @"' class='info-cell sang'>
                                        <ul class='list-info'>
                                        </ul>
                                    </td>";
        

                        
                        if(dem == 3)
                        {
                            index = dem;
                            break;
                        }
                    }

                    html += "<tr class='odds'>" + htmlTemp + "</tr>";

                }
                
                firstDate = firstDate.AddDays(1);
            }

            return "<table><tbody>" + html + "</tbody></table>";
        }
    }
}
