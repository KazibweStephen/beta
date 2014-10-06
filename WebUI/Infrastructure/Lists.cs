using System;

namespace WebUI.Infrastructure
{
    public class Lists
    {
        public static String[] Gender
        {
            get
            {
                return new[] { "Male", "Female" };
            }
        }

        public static String[] Nationalities
        {
            get
            {
                return new[]
            {
                "Afghan", "Albanian", "Algerian", "American", "Andorran", "Angolan", "Antiguans", "Argentinean",
                "Armenian", "Australian", "Austrian",
                "Azerbaijani", "Bahamian", "Bahraini", "Bangladeshi", "Barbadian", "Barbudans", "Batswana",
                "Belarusian", "Belgian", "Belizean", "Beninese",
                "Bhutanese", "Bolivian", "Bosnian", "Brazilian", "British", "Bruneian", "Bulgarian", "Burkinabe",
                "Burmese", "Burundian", "Cambodian", "Cameroonian",
                "Canadian", "Cape Verdean", "Central African", "Chadian", "Chilean", "Chinese", "Colombian",
                "Comoran", "Congolese", "Costa Rican", "Croatian", "Cuban",
                "Cypriot", "Czech", "Danish", "Djibouti", "Dominican", "Dutch", "East Timorese", "Ecuadorean",
                "Egyptian", "Emirian", "Equatorial Guinean", "Eritrean",
                "Estonian", "Ethiopian", "Fijian", "Filipino", "Finnish", "French", "Gabonese", "Gambian",
                "Georgian", "German", "Ghanaian", "Greek", "Grenadian", "Guatemalan",
                "Guinea-Bissauan", "Guinean", "Guyanese", "Haitian", "Herzegovinian", "Honduran", "Hungarian",
                "I-Kiribati", "Icelander", "Indian", "Indonesian", "Iranian", "Iraqi",
                "Irish", "Israeli", "Italian", "Ivorian", "Jamaican", "Japanese", "Jordanian", "Kazakhstani",
                "Kenyan", "Kittian and Nevisian", "Kuwaiti", "Kyrgyz", "Laotian", "Latvian",
                "Lebanese", "Liberian", "Libyan", "Liechtensteiner", "Lithuanian", "Luxembourger", "Macedonian",
                "Malagasy", "Malawian", "Malaysian", "Maldivan", "Malian", "Maltese", "Marshallese",
                "Mauritanian", "Mauritian", "Mexican", "Micronesian", "Moldovan", "Monacan", "Mongolian", "Moroccan",
                "Mosotho", "Motswana", "Mozambican", "Namibian", "Nauruan", "Nepalese", "New Zealander",
                "Nicaraguan", "Nigerian", "Nigerien", "North Korean", "Northern Irish", "Norwegian", "Omani",
                "Pakistani", "Palauan", "Panamanian", "Papua New Guinean", "Paraguayan", "Peruvian", "Polish",
                "Portuguese",
                "Qatari", "Romanian", "Russian", "Rwandan", "Saint Lucian", "Salvadoran", "Samoan", "San Marinese",
                "Sao Tomean", "Saudi", "Scottish", "Senegalese", "Serbian", "Seychellois", "Sierra Leonean",
                "Singaporean",
                "Slovakian", "Slovenian", "Solomon Islander", "Somali", "South African", "South Korean", "Spanish",
                "Sri Lankan", "Sudanese", "Surinamer", "Swazi", "Swedish", "Swiss", "Syrian", "Taiwanese", "Tajik",
                "Tanzanian",
                "Thai", "Togolese", "Tongan", "Trinidadian or Tobagonian", "Tunisian", "Turkish", "Tuvaluan",
                "Ugandan", "Ukrainian", "Uruguayan", "Uzbekistani", "Venezuelan", "Vietnamese", "Welsh", "Yemenite",
                "Zambian", "Zimbabwean"
            };
            }
        }

        public static String[] Countries
        {
            get
            {
                return new[]
            {
                "Afghanistan", "Åland Islands", "Albania", "Algeria", "American Samoa", "Andorra", "Angola",
                "Anguilla", "Antarctica", "Antigua And Barbuda", "Argentina", "Armenia", "Aruba", "Australia",
                "Austria", "Azerbaijan",
                "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda",
                "Bhutan", "Bolivia", "Bosnia And Herzegovina", "Botswana", "Bouvet Island", "Brazil",
                "British Indian Ocean Territory", "Brunei Darussalam",
                "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde",
                "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Christmas Island",
                "Cocos (keeling) Islands", "Colombia", "Comoros", "Congo", "Congo, The Democratic Republic",
                "Cook Islands",
                "Costa Rica", "CÔte D'ivoire", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti",
                "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea",
                "Estonia", "Ethiopia", "Falkland Islands (malvinas)", "Faroe Islands", "Fiji", "Finland", "France",
                "French Guiana", "French Polynesia", "French Southern Territories", "Gabon", "Gambia", "Georgia",
                "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala",
                "Guernsey", "Guinea", "Guinea-bissau", "Guyana", "Haiti", "Heard Island And Mcdonald Islands",
                "Honduras", "Hong Kong",
                "Hungary", "Iceland", "India", "Indonesia", "Iran, Islamic Republic", "Iraq", "Ireland",
                "Isle Of Man", "Israel", "Italy", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya",
                "Kiribati", "Korea, Democratic People's Republic", "Korea, Republic", "Kuwait", "Kyrgyzstan",
                "Lao People's Democratic Republic", "Latvia",
                "Lebanon", "Lesotho", "Liberia", "Libyan Arab Jamahiriya", "Liechtenstein", "Lithuania",
                "Luxembourg", "Macao", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta",
                "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia",
                "Moldova", "Monaco", "Mongolia", "Montenegro",
                "Montserrat", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands",
                "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue",
                "Norfolk Island", "Northern Mariana Islands", "Norway", "Oman", "Pakistan", "Palau", "Palestine",
                "Panama", "Papua New Guinea", "Paraguay", "Peru",
                "Philippines", "Pitcairn", "Poland", "Portugal", "Puerto Rico", "Qatar", "RÉunion", "Romania",
                "Russia", "Rwanda", "Saint BarthÉlemy", "Saint Helena", "Saint Kitts And Nevis", "Saint Lucia",
                "Saint Martin", "Saint Pierre And Miquelon", "Saint Vincent And The Grenadines", "Samoa",
                "San Marino", "Sao Tome And Principe", "Saudi Arabia", "Senegal",
                "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands",
                "Somalia", "South Africa", "South Georgia And The South Sandwich Islands", "Spain", "Sri Lanka",
                "Sudan", "Suriname", "Svalbard And Jan Mayen", "Swaziland", "Sweden", "Switzerland",
                "Syrian Arab Republic", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor-leste",
                "Togo", "Tokelau", "Tonga", "Trinidad And Tobago", "Tunisia", "Turkey", "Turkmenistan",
                "Turks And Caicos Islands", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom",
                "United States", "United States Minor Outlying Islands", "Uruguay", "Uzbekistan", "Vanuatu",
                "Vatican City State", "Venezuela", "Viet Nam", "Virgin Islands, British", "Virgin Islands, U.S",
                "Wallis And Futuna",
                "Western Sahara", "Yemen", "Zambia", "Zimbabwe"
            };
            }
        }

        public enum SystemRolesEnum
        {
            Administrator,
            Employee,
            Executive,
            HumanResource
        }

        public static String[] SystemRoles
        {
            get
            {
                return new[]
            {
                "System Administrator", "Human Resource Personnel (IBP)", "Executive"
            };
            }
        }

        public static String[] MaritalStatus
        {
            get
            {
                return new[]
            {
                "Single", "Married", "Civil Marriage", "Cohabiting (over 2 years)"
            };
            }
        }

        public static String[] CommonDepartmentNames
        {
            get
            {
                return new[]
            {
                "Marketing", "Human Resources", "Finance", "Procurement", "Sales", "IT", "Customer Service"
            };
            }
        }

        public static String[] YesOrNo
        {
            get
            {
                return new[] { "Yes", "No" };
            }
        }

        public static String[] CommonCurrencies
        {
            get
            {
                return new[] { "USD", "UGX", "RWF", "KSH", "TSH", "SSP" };
            }
        }

        public static String[] EmployeeCategories
        {
            get
            {
                return new[] { "Skilled", "Semi-Skilled", "Expatriates", "Nationals", "Non-Nationals", "EAC Community" };
            }
        }

        public static String[] EmployeeStatuses
        {
            get
            {
                return new[] { "Active", "Laid Off", "On Leave", "Pending", "Quit", "Terminated" };
            }
        }

        public static String[] BetCategories
        {
            get
            {
                return new[]
                {"FT 1x2", "FT U/O","HT 1x2","HT U/O" ,"Double Chance", "Handicap" , "Both Teams To Score", "First Team To Score" ,"Draw No Bet" };
            }
        }
    }

}