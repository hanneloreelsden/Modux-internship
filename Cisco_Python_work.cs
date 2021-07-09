﻿using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections;

namespace Cisco_Python_work
{
    static class decryption
    {
        static string salt = "dsfd;kfoA,.iyewrkldJKDHSUBsgvca69834ncxv9873254k;fg87";

        static void Decrypter(string pw)
        {
            int index = Int32.Parse(pw.Substring(0,2));
            string enc_pw = pw.Substring(2).Trim();
            Console.WriteLine(enc_pw);
            var hex_pw = string.Empty;
            int i = 0;
            while ((i+=2)< enc_pw.Length)
            {
                hex_pw+=(enc_pw.Substring(i,2));
            }
            Console.WriteLine(hex_pw);
            // Create the cleartext list
            string cleartext = string.Empty;
            for(int j=0; j<hex_pw.Length; j+=1)
            {
                int cur_index = (j+index) % 53;
                var cur_salt = Char.ConvertToUtf32(salt,cur_index);
                int cur_hex_int = Int32.Parse(hex_pw.Substring(j, j));
                var cleartext_char = cur_salt ^ cur_hex_int;  
                cleartext+=(cleartext_char);
            }
            Console.WriteLine(cleartext);
        }
        
        
        static void Main()
        {
            //input password here
            Decrypter("3830135554587b535b5a0e5709155d");
        }
    }
}
