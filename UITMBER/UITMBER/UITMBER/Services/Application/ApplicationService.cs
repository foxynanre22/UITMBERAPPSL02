using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Application;
using UITMBER.Services.Request;
using Xamarin.Forms;

namespace UITMBER.Services.Application
{
    public class ApplicationService : IApplicationService
    {
        public IRequestService _requestService => DependencyService.Get<IRequestService>();

        public async Task<bool> SendApplication(SendApplicationRequest input)
        {
            var uri = $"{Settings.SERVER_ENDPOINT}/Application/SendApplication";

            await _requestService.PostAsync<SendApplicationRequest>(uri, input);

            return true;
        }

        public async Task<List<GetApplicationResponse>> GetMyApplications()
        {
            //var uri = $"{Settings.SERVER_ENDPOINT}/Application/GetMyApplications";

            //return await _requestService.GetAsync<List<GetApplicationResponse>>(uri);
            List<GetApplicationResponse> test1 = new List<GetApplicationResponse>();
            test1.Add(new GetApplicationResponse
            {
                Accepted = true,
                CarId = 1,
                Date = DateTime.Now,
                DriverLicenceNo = "214125125",
                DriverLicencePhoto = "https://dps.mn.gov/divisions/dvs/PublishingImages/new-cards/real-id-star.jpg",                
                Id = 1,
                UserId = 1

            }
            ) ;
            test1.Add(new GetApplicationResponse
            {
                Accepted = true,
                CarId = 3,
                Date = DateTime.Now,
                DriverLicenceNo = "214864125",
                DriverLicencePhoto = "https://whyy.org/wp-content/uploads/2020/05/realid-1-768x432.jpg",
                Id = 2,
                UserId = 2

            }

            );
            return  test1;
        }

    }
}
