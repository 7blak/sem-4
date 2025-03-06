using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD1.Observer
{
    public interface IIDUpdater
    {
        public void UpdateID(UInt64 ID, UInt64 NewObjectID);
    }
    public interface IPositionUpdater
    {
        public void UpdatePosition(UInt64 ID, FTRObjects.Location location);
    }
    public interface IContactInfoUpdater
    {
        public void UpdateContactInfo(UInt64 ID, string phoneNumber, string emailAddress);
    }
    public static class Observer
    {
        private static List<IIDUpdater> IDUpdaters = new List<IIDUpdater>();
        private static List<IPositionUpdater> positionUpdaters = new List<IPositionUpdater>();
        private static List<IContactInfoUpdater> contactInfoUpdaters = new List<IContactInfoUpdater>();

        public static void SubToUpdater(IIDUpdater updater)
        {
            IDUpdaters.Add(updater);
        }
        public static void UnsubFromUpdater(IIDUpdater updater)
        {
            IDUpdaters.Remove(updater);
        }
        public static void SubToPosUpdater(IPositionUpdater posUpdater)
        {
            positionUpdaters.Add(posUpdater);
        }
        public static void UnsubFromPosUpdater(IPositionUpdater posUpdater)
        {
            positionUpdaters.Remove(posUpdater);
        }
        public static void SubToContactUpdater(IContactInfoUpdater contactInfoUpdater)
        {
            contactInfoUpdaters.Add(contactInfoUpdater);
        }
        public static void UnsubFromContactUpdater(IContactInfoUpdater contactInfoUpdater)
        {
            contactInfoUpdaters.Remove(contactInfoUpdater);
        }
        public static void NotifyIDUpdaters(UInt64 ID, UInt64 newID)
        {
            foreach (var updater in IDUpdaters)
                updater.UpdateID(ID, newID);
        }
        public static void NotifyPosUpdaters(UInt64 ID, FTRObjects.Location location)
        {
            foreach (var updater in positionUpdaters)
                updater.UpdatePosition(ID, location);
        }
        public static void NotifyContactInfoUpdaters(UInt64 ID, string phoneNumber, string emailAddress)
        {
            foreach (var updater in contactInfoUpdaters)
                updater.UpdateContactInfo(ID, phoneNumber, emailAddress);
        }
    }
}
