using System;

namespace Cielo.Sdk.Domain
{
    /// <summary>
    /// Refer to: cielo.orders.domain.Status
    /// </summary>
    public static class Status
    {
        public static String DRAFT
        {
            get
            {
                return "DRAFT";
            }
        }
        public static String ENTERED
        {
            get
            {
                return "ENTERED";
            }
        }
        public static String CANCELED
        {
            get
            {
                return "CANCELED";
            }
        }
        public static String PAID
        {
            get
            {
                return "PAID";
            }
        }
        public static String APPROVED
        {
            get
            {
                return "APPROVED";
            }
        }
        public static String REJECTED
        {
            get
            {
                return "REJECTED";
            }
        }
        public static String RE_ENTERED
        {
            get
            {
                return "RE_ENTERED";
            }
        }
        public static String CLOSED
        {
            get { return "CLOSED"; }
        }

    }
}
