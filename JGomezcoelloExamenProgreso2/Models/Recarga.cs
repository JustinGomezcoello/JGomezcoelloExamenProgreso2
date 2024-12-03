using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JGomezcoelloExamenProgreso2.Models
{
    public class Recarga : INotifyPropertyChanged
    {
        private string _telefono;
        private string _nombre;
        private string _ultimaRecarga;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Telefono
        {
            get => _telefono;
            set
            {
                _telefono = value;
                OnPropertyChanged();
            }
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        public string UltimaRecarga
        {
            get => _ultimaRecarga;
            set
            {
                _ultimaRecarga = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
