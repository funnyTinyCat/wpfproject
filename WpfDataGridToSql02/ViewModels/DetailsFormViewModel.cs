﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfDataGridToSql02.ViewModels
{
    public class DetailsFormViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }

            set 
            { 
                _username = value; 
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private bool _isSubscribed;
        public bool IsSubscribed
        {
            get { return _isSubscribed; }

            set
            {
                _isSubscribed = value;
                OnPropertyChanged(nameof(IsSubscribed));
            }
        }

        private bool _isMember;
        public bool IsMember
        {
            get { return _isMember; }

            set
            {
                _isMember = value;
                OnPropertyChanged(nameof(IsMember));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
 
        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get
            {
                return _isSubmitting;
            }
            set
            {
                _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmitting));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(Username);


        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public DetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

    }
}
