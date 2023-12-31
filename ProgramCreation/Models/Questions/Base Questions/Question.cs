﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
    //Base class for all Questions
    //As it contains All the required data that will be needed in each question..may by other questions will have additional data
    //and then those data will be added in their classes
    public abstract class Question
    {
        private string _id;
        private string _title;
        private string _type;
        private string _sectionName;
        private bool? _isHidden;
        private bool? _isMandatory;
        private bool? _isInternal;

        public string id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }

        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public string SectionName
        {
            get { return this._sectionName; }
            set { this._sectionName = value; }
        }

        public bool? IsHidden
        {
            get { return this._isHidden; }
            set { this._isHidden = value; }
        }

        public bool? IsInternal
        {
            get { return this._isInternal; }
            set { this._isInternal = value; }
        }

        public bool? IsMandatory
        {
            get { return this._isMandatory; }
            set { this._isMandatory = value; }
        }

        public Question(string id, string title, string sectionName)
        {
            this.id = id;
            this.Title = title;
            this.SectionName = sectionName;
            this.IsHidden = false;
            switch (this.SectionName)
            {
                case "Personal Information":
                    this.IsInternal = false; break;
                case "Profile":
                    this.IsMandatory = false; break;
                default:
                    break;
            }
        }
    }
}
