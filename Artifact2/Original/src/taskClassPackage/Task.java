package taskClassPackage;

public class Task {

	//This variable is specific to assigning an ID to a task and does not change.
	private String task_ID;
	
	//The name of the task and the task's description.
	private String name;
	private String desc;
	
	//A constructor that assigns the starting variables to themselves.
	public Task(String task_ID, String name, String desc)
	{
		if (task_ID == null || task_ID.length() > 10)
		{
			throw new IllegalArgumentException("Invalid Task ID");
		}
		
		if(name == null || name.length() > 20)
		{
			throw new IllegalArgumentException("Invalid Task Name");
		}
		
		if(desc == null || desc.length() > 50)
		{
			throw new IllegalArgumentException("Invalid Task Description");
		}
		this.task_ID = task_ID;
		this.name = name;
		this.desc = desc;
	}
	
	//A getter that gets the task ID's information.
	public String GetTaskID()
	{
		
		return task_ID;
	}
	
	//A getter that gets the name of the task.
	public String GetName()
	{
		
		return name;
	}
	
	//A setter that sets the task's name.
	public void SetName(String name)
	{
		if(name == null || name.length() >20)
		{
			throw new IllegalArgumentException("Invalid Task Name");
		}
		this.name = name;
	}
	
	//A getter that gets the description assigned to the task.
	public String GetDesc()
	{
		
		return desc;
	}
	
	//A setter that sets the description of the task.
	public void SetDesc(String desc)
	{
		if(desc == null || desc.length() > 50)
		{
			throw new IllegalArgumentException("Invalid Task Description");
		}
		
		this.desc = desc;
	}
}
