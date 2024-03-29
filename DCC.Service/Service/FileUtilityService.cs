﻿using DCC.ModelSQL.Models;
using DCC.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace DCC.Service.Service
{
    public class FileUtilityService : IFileUtilityService
    {
        private IConfiguration _configuration;
        private IWebHostEnvironment _hostEnvironment;


        public FileUtilityService(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _hostEnvironment = webHostEnvironment;
        }


        public (IList<EmpHistory>, string response) ReadBrokerMasterFromExcel(string filePath)
        {
            throw new NotImplementedException();
        }

        public async   Task<string> WriteIFormFileOnNetwork(IFormFile file, string fileName)
        {
           
            string filePath = _configuration["ShareFolderPath:SupportOfficeOUT"];

         //  string path = Path.Combine(_hostEnvironment.WebRootPath, "uploads");

            if (file.Length > 0)
            {
                string fileExtension = GetFileExtenison(file.FileName);
                filePath = Path.Combine(filePath, fileName + "." + fileExtension);
                try
                {
                    using (Stream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    return "X99" + ex.Message;
                }
                return fileName + "." + fileExtension;
               
            }
            return null;
        }

        public Task<string> WriteIFormFileToDisk(IFormFile file)
        {
            throw new NotImplementedException();
        }


        public string GetFileExtenison(string fileName)
        {
            var fileExtension = fileName.Split('.').LastOrDefault();
            return fileExtension;
        }

        public string GetFileNameWithoutExtension(string path)
        {
            throw new NotImplementedException();
        }

    }
}
