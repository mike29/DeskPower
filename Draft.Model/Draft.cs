using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace DeskPowerApp.Model
{
    /// <summary>
    /// A draft is an article writeen by journalist and not published
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class Draft: INotifyPropertyChanged
    {

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        protected bool SetField<T>(ref T field, T value,
       [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Gets or sets the draft identifier.
        /// </summary>
        /// <value>
        /// The draft identifier.
        /// </value>
        public int DraftId { get; set; }

        /// <summary>
        /// Gets or sets the draf title.
        /// </summary>
        /// <value>
        /// The draf title.
        /// </value>
        [Required]
        public string DraftTitle { get; set; }

        /// <summary>
        /// Gets or sets the content of the draft.
        /// </summary>
        /// <value>
        /// The content of the draft.
        /// </value>
        [Required]
        public string DraftContent { get; set; }

        /// <summary>
        /// Gets or sets the draft category.
        /// </summary>
        /// <value>
        /// The draft category.
        /// </value>
        public DraftCategories DraftCategory { get; set; }

        /// <summary>
        /// The draft image URL
        /// </summary>
        private string draftImageUrl;
        /// <summary>
        /// Gets or sets the draft image URL.
        /// </summary>
        /// <value>
        /// The draft image URL.
        /// </value>
        public string DraftImageUrl {
            get { return draftImageUrl; }
            set { SetField(ref draftImageUrl, value); }
        }

        /// <summary>
        /// Gets or sets the draft created date.
        /// </summary>
        /// <value>
        /// The draft created date.
        /// </value>
        public DateTime DraftCreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the people/journalists.
        /// </summary>
        /// <value>
        /// The people.
        /// </value>
        public virtual ObservableCollection<Person> Writter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Draft"/> class.
        /// </summary>
        public Draft()
        {
            
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return DraftId + "";
        }

    }
}
/// <summary>
/// A list of articles catagories that is assigned to have control on article types
/// </summary>
public enum DraftCategories
    {
        Sport,
        Poletic,
        Entertainment,
        History,
        Blog
       
    }

