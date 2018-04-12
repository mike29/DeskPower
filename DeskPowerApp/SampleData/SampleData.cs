using DeskPowerApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskPowerApp.SampleData
{
    public class SampleData
    {
        public ObservableCollection<Draft> DraftSamplpeData { get; set; }
        public ObservableCollection<Person> PersonSampleData { get; set; }


        public SampleData()
        {
            DraftSamplpeData = new ObservableCollection<Draft>()
            {
                new Draft()
                {
                    DraftID= 001,
                    DrafTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImage = "ms-appx:///Assets/img/BGJournalist.png"

                },
                  new Draft()
                {
                    DraftID= 002,
                    DrafTitle = "Me my Self and I",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Blog,
                    DraftImage = "ms-appx:///Assets/img/BGJournalist.png"

                },
                    new Draft()
                {
                    DraftID= 003,
                    DrafTitle = "Hiof university college forsker jukset",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined ",
                    DraftCategory = DraftCategories.Blog,
                    DraftImage = "ms-appx:///Assets/img/BGJournalist.png"

                },
                      new Draft()
                {
                    DraftID= 004,
                    DrafTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Blog,
                    DraftImage = "ms-appx:///Assets/img/BGJournalist.png"

                },
                       new Draft()
                {
                    DraftID= 004,
                    DrafTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImage = "ms-appx:///Assets/img/BGJournalist.png"

                },
                        new Draft()
                {
                    DraftID= 004,
                    DrafTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImage = "ms-appx:///Assets/img/BGJournalist.png"

                },
                          new Draft()
                {
                    DraftID= 004,
                    DrafTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImage = "ms-appx:///Assets/img/BGJournalist.png"

                },
                          new Draft()
                {
                    DraftID= 004,
                    DrafTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImage = "ms-appx:///Assets/img/BGJournalist.png"

                },
                     new Draft()
                {
                    DraftID= 004,
                    DrafTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImage = "ms-appx:///Assets/img/BGJournalist.png"

                }

            };
            Draft dr = new Draft{
                DraftID = 001,
                DrafTitle = "Donald Trump utro",
                DraftContent = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                DraftCategory = DraftCategories.Poletic,
                DraftImage = "ms-appx:///Assets/img/BGJournalist.png"
            };
           
            PersonSampleData = new ObservableCollection<Person>()
            {
                new Person()
                {
                    PersonID = 01,
                    FirstName = "Jonas",
                    LastName = "Vestgarden",
                    Position = "Jornalist",

                },

                    new Person()
                {
                    PersonID = 02,
                    FirstName = "Michael",
                    LastName = "Simon",
                    Position = "Jornalist",
                    

                }

            }; 
            }


        public Draft GetDaraftWritenByJornalist(Draft draft_, ObservableCollection<Draft> draftCollection)
        {
           
               
            foreach (Draft drafts in draftCollection)
            {
                if (drafts == draft_ )
                {
                    return drafts; 
                }
                else
                {
                    return draft_; 
                }
                // You can get cust.CustName
                // and you can get cust.CustEmail
            }
            return draft_; 
            
        }
    }
}
