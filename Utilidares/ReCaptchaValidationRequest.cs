using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class ReCaptchaValidationRequest
    {
        public string ReCaptchaResponse { get; set; }
        public string SecretKey { get; set; }
    }

}
