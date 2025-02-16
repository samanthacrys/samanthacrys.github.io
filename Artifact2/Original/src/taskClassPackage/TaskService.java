package taskClassPackage;

import java.util.HashMap;
import java.util.Map;

public class TaskService {
	
	//This creates a map that stores the tasks.
	private final Map<String, Task> tasks;
	
	//A constructor that creates a new hash map that is labeled as tasks.
	public TaskService()
	{
		tasks = new HashMap<>();
	}
	
	//Adds a task to the list by putting information from the taskID getter and the 
	//task itself.
	public boolean AddTask(Task task)
	{
		if(tasks.containsKey(task.GetTaskID()))
		{
			throw new IllegalArgumentException("Task ID already exists.");
		}
		
		tasks.put(task.GetTaskID(), task);
		
		return true;
	}
	
	//Removes a task from the tasks map that is connected to the task_ID.
	public boolean DeleteTask(String task_ID)
	{
		if(tasks.containsKey(task_ID))
		{
			tasks.remove(task_ID);
			
			return true;
		}
		
		return false;
	}
	
	//Updates the name of the task when it is changed and renames it. This uses the
	//task_ID to ensure that the correct name is changed. This checks that our task is not
	//null and, if it isn't, renames it by setting the name.
	public void UpdateTaskName(String task_ID, String updatedName)
	{
		Task task = tasks.get(task_ID);
		
		if(task == null)
		{
			throw new IllegalArgumentException("Task ID does not exist.");
		}
		
		task.SetName(updatedName);
	}
	
	//Updates the task's description. Using the task ID, it checks if our task is 
	//not null. If it is not, it takes the current description and sets it to the new
	//inputs.
	public void UpdateTaskDesc(String task_ID, String newDesc)
	{
		
		Task task = tasks.get(task_ID);
		
		if(task == null)
		{
			throw new IllegalArgumentException("Task ID does not exist.");
		}
		
		task.SetDesc(newDesc);
	}
	
	//This gets a task from the task_ID.
	public Task GetTask(String task_ID)
	{
		
		return tasks.get(task_ID);
	}
}
