﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Recruitment.Common.Models;

namespace Recruitment.HashFunction.Services
{
    public class Hash : IHash
    {
        public string GenerateHash(LoginDataRequest logindata)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes($"{logindata.Login}{logindata.Password}"));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
