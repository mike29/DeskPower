using DeskPowerApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Collections.ObjectModel; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskPowerApp.DataAcess
{
    public class DeskPowerAppIntializer: DropCreateDatabaseIfModelChanges<DeskPowerAppContext>
    {
        protected override void Seed(DeskPowerAppContext context)
        {
            var Michael = context.Persons.Add(new Person() { FirstName="Michael" ,LastName="Simon", Position="Journalist"});
            var Daniel = context.Persons.Add(new Person() { FirstName = "Daniel", LastName = "Ole", Position = "Journalist" });

            context.Persons.Add(new Person() { FirstName = "Adis", LastName = "Jas", Position="Chief Editor"});
            context.Persons.Add(new Person() { FirstName = "David", LastName = "Jango", Position = "Journalist" });

            context.Drafts.Add(new Draft()
            {
                DraftTitle = "Me my Self and I",
                DraftContent = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                DraftCategory = DraftCategories.Blog,
                DraftImageUrl = "ms-appx:///Assets/img/equipment.jpg",
                Writter = new ObservableCollection<Person>() { Michael }

            });
            context.Drafts.Add(new Draft()
            {
                DraftTitle = "Donald Trump utro",
                DraftContent = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                DraftCategory = DraftCategories.Blog,
                DraftImageUrl = "ms-appx:///Assets/img/music.jpg",
                Writter = new ObservableCollection<Person>() { Daniel }

            });

            context.Drafts.Add(new Draft()
            {
                DraftTitle = "Me my Self and I",
                DraftContent = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                DraftCategory = DraftCategories.Blog,
                DraftImageUrl = "ms-appx:///Assets/img/photo-1504.jpg",
                Writter = new ObservableCollection<Person>() { Daniel }

            });

            context.Drafts.Add(new Draft()
            {
                DraftTitle = "Hiof university college forsker jukset",
                DraftContent = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined ",
                DraftCategory = DraftCategories.Blog,
                DraftImageUrl = "ms-appx:///Assets/img/photo-1504.jpg",
                Writter = new ObservableCollection<Person>() { Daniel }

            });

            context.Drafts.Add(new Draft()
            {
                DraftTitle = "Donald Trump ",
                DraftContent = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                DraftCategory = DraftCategories.Blog,
                DraftImageUrl = "ms-appx:///Assets/img/music.jpg",
                Writter = new ObservableCollection<Person>() { Daniel }

            });

            context.Drafts.Add(new Draft()
            {
                DraftTitle = "The US Trump ",
                DraftContent = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                DraftCategory = DraftCategories.Poletic,
                DraftImageUrl = "ms-appx:///Assets/img/gun.jpg",
                Writter = new ObservableCollection<Person>() { Daniel }

            });

            context.Drafts.Add(new Draft()
            {
                DraftTitle = "Donald Trump utro",
                DraftContent = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                DraftCategory = DraftCategories.Poletic,
                DraftImageUrl = "ms-appx:///Assets/img/music.jpg",
                Writter = new ObservableCollection<Person>() { Daniel }

            });



            base.Seed(context);

        }


        }
}
