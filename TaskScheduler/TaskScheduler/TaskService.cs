namespace TaskScheduler

{
    //This class contains the information for adding/creating, deleting, updating name, updating description, and
    //getting a task. This is the main class that the TaskServiceTest class accesses.
    public class TaskService
    {
        //This is a readonly dictionary that holds the different tasks that are created. This is set to new
        //for creating a new task when adding into the dictionary.
        private readonly Dictionary<string, Task> _tasks = new();

        //This adds a task to the dictionary. This ensures that a new task with the ID that is input into it as
        //a new Dictionary entry. This simply returns the task using the TryAdd to add a new entry into the dictionary.
        public bool AddTask(Task task)
        {
            return _tasks.TryAdd(task.Id, task);
        }

        //This method is used to delete a task. The way that this is done is by checking that the key does not exist.
        //This key is the ID associated with the specific task the user wants to delete. By checking for the key,
        //it knows whether or not to delete a task. If the task ID does not exist, then it will do nothing, but it will
        //if there is and then access the remove function and return true when this is completed.
        public bool DeleteTask(Task task)
        {
            if (!_tasks.ContainsKey(task.Id))
            {
                return false;
            }
            _tasks.Remove(task.Id);

            return true;

        }

        //This task assigns a name to the task when it is changed. By accessing the task's name element, it is
        //allowing for assigning the new name to the Name element.
        public static void UpdateTaskName(Task task, string newName)
        {
            task.Name = newName;
        }

        //This updates the description for the task. The way that this is done is by accessing the description 
        //that was already set and replacing it with what is stored in the newDesc variable.
        public static void UpdateTaskDesc(Task task, string newDesc)
        {
            task.Description = newDesc;
        }

        //This evaluates for getting a task. This looks at the taskId that is put in and checks whether that exists.
        //If it does exist, then it will return the information stored within the task. Otherwise, it has nothing to
        //display.
        public Task? GetTask(string taskId)
        {
            _tasks.TryGetValue(taskId, out Task? task);
            return task;
        }
    }
}

