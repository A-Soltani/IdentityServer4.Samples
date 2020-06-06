using IdentityManaging.Domain.AggregatesModel.UserAggregate.UserPersonalInformation;
using IdentityManaging.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityManaging.Domain.AggregatesModel.UserAggregate
{
    public class User: IAggregateRoot
    {
        public UserProfileInfo UserProfileInfo { get; private set; }
        public UserPersonalInfo PersonalInfo { get; private set; }
        public UserPasswordInfo UserPasswordInfo { get; private set; }

        private User(UserProfileInfo userProfileInfo, UserPersonalInfo personalInfo, UserPasswordInfo userPasswordInfo)
        {
            UserProfileInfo = userProfileInfo;
            PersonalInfo = personalInfo;
            UserPasswordInfo = userPasswordInfo;
        }

        public static User RegisterUser(UserProfileInfo userProfileInfo, UserPersonalInfo personalInfo, UserPasswordInfo userPasswordInfo)
        {
            return new User(userProfileInfo, personalInfo, userPasswordInfo);
        }
    }
}
