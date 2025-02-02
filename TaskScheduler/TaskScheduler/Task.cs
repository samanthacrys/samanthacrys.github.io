namespace TaskScheduler

{   
    //This is the Task class. The components within this class is set to allow for sending error messages and the base
    //framework for how a Task is set up. This also sets the allowed lengths of the task's ID, name, and descriptions
    //to their maximum values.
    public class Task
    {
        //A constant integer that limits the length of the Task ID to 10 total integers' in length.
        public const int MaxTaskIdLength = 10;

        //This is a private string that is meant for showing the maximum length of the Task ID. It contains the
        //error message that the user receives.
        private static readonly string errorMsgInvalidTaskId =
            $"Task ID is invalid, please provide one no greater than "+
            $"{MaxTaskIdLength} characters.";

        //A constant integer that limits the length of the Task name to 10 total integers' in length.
        public const int MaxTaskNameLength = 20;

        //This is a private string that is meant for showing the maximum length of the task's name. It contains the
        //error message that the user receives.
        private static readonly string errorMsgInvalidTaskName =
            $"Task name invalid, please provide one no greater than " +
            $"{MaxTaskNameLength} characters.";

        //A constant integer that limits the length of the Task description to 10 total integers' in length.
        public const int MaxTaskDescriptionLength = 50;

        //This is a private string that is meant for showing the maximum length of the Task's description. It contains
        //the error message that the user receives.
        private static readonly string errorMsgInvalidTaskDescription =
            $"Task description invalid, please provide one no greater than" +
            $"{MaxTaskDescriptionLength} characters.";        

       //This is the constructor that assigns the string variables of id, name, and desc to their connecting
       //variables of Id, Name, and Description.
        public Task(string id, string name, string desc)
        {
            Id = id;
            Name = name;
            Description = desc;
        }
        
        //This is a string that starts off as empty and will contain the information for the ID.
        private string _id = string.Empty;
        
        //This is a getter and setter. This gets the ID, but sets it to make sure that it is not
        //exceeding the maximum number of allowed integers. If it does happen, then an invalid message is thrown
        //from the matching variable.
        public string Id
        {
            get => _id;
            private set
            {
                if ( string.IsNullOrEmpty(value) || value.Length > MaxTaskIdLength )
                {
                    throw new ArgumentException(errorMsgInvalidTaskId);
                }
                _id = value;
            }
        }

        //This is a string that starts off as empty and will contain the information for the name.
        private string _name = string.Empty; 

        //This is a getter and setter. This gets the name, but sets it to make sure that it is not
        //exceeding the maximum number of allowed integers. If it does happen, then an invalid message is thrown
        //from the matching variable.
        public string Name
        {
            get => _name;
            set
            {
                if(string.IsNullOrEmpty(value) || value.Length >MaxTaskNameLength)
                {
                    throw new ArgumentException(errorMsgInvalidTaskName);
                }
                _name = value;
            }
        }
        
        //This is a string that starts off as empty and will contain the information for the description.
        private string _description = string.Empty;
        
        //This is a getter and setter. This gets the description, but sets it to make sure that it is not
        //exceeding the maximum number of allowed integers. If it does happen, then an invalid message is thrown
        //from the matching variable.
        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > MaxTaskDescriptionLength)
                {
                    throw new ArgumentException(errorMsgInvalidTaskDescription);
                }
                _description = value;
            }
        }
    }
}

