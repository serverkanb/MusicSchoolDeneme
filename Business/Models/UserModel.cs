﻿#nullable disable
using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class UserModel : RecordBase
    {
        #region Entitiden gelenler
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }
        #endregion

        #region Yeni İhtiyaç
        public string RoleName { get; set; }

        #endregion
    }
}