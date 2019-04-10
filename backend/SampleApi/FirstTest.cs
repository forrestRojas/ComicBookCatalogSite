using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SampleApi.API;

namespace SampleApi
{
    /// <summary>
    /// The entry point for the api.
    /// </summary>
    public class FirstTest
    {
        /// <summary>
        /// Entry point method for the api.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            
            int volumeId = GetComicInfo.GetVolumeInfo("Omaha the Cat Dancer");
            object issue = GetComicInfo.GetIssueInfo(volumeId, 14);
        }
