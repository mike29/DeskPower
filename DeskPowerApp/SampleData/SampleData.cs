﻿using DeskPowerApp.Model;
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
                    DraftId= 100,
                    DraftTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImageUrl = "ms-appx:///Assets/img/gun.jpg"

                },
                  new Draft()
                {
                    DraftId= 200,
                    DraftTitle = "Me my Self and I",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Blog,
                    DraftImageUrl = "ms-appx:///Assets/img/equipment.jpg"

                },
                    new Draft()
                {
                    DraftId= 300,
                    DraftTitle = "Hiof university college forsker jukset",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined ",
                    DraftCategory = DraftCategories.Blog,
                    DraftImageUrl = "ms-appx:///Assets/img/photo-1504.jpg"

                },
                      new Draft()
                {
                    DraftId= 400,
                    DraftTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Blog,
                    DraftImageUrl = "ms-appx:///Assets/img/music.jpg"

                },
                       new Draft()
                {
                    DraftId= 500,
                    DraftTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImageUrl = "ms-appx:///Assets/img/ptree.jpg"

                },
                        new Draft()
                {
                    DraftId= 004,
                    DraftTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImageUrl = "ms-appx:///Assets/img/BGJournalist.png"

                },
                          new Draft()
                {
                    DraftId= 600,
                    DraftTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImageUrl = "ms-appx:///Assets/img/police.jpg"

                },
                          new Draft()
                {
                    DraftId= 700,
                    DraftTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImageUrl = "ms-appx:///Assets/img/gun.jpg"

                },
                     new Draft()
                {
                    DraftId= 800,
                    DraftTitle = "Donald Trump utro",
                    DraftContent="There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                    DraftCategory = DraftCategories.Poletic,
                    DraftImageUrl = "ms-appx:///Assets/img/music.jpg"

                },

            
           new Draft{
                DraftId = 900,
                DraftTitle = "...........",
                DraftContent = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined",
                DraftCategory = DraftCategories.Poletic,
                DraftImageUrl = "ms-appx:///Assets/img/ptree.jpg"
           }
            };
           
            PersonSampleData = new ObservableCollection<Person>()
            {
                new Person()
                {
                    PersonId = 01,
                    FirstName = "Jonas",
                    LastName = "Vestgarden",
                    Position = "Jornalist",

                },

                    new Person()
                {
                    PersonId = 02,
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
