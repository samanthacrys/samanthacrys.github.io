package taskClassPackage;

import org.junit.jupiter.api.BeforeEach;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;

public class TaskServiceTest {

	private TaskService taskService;
	
	@BeforeEach
	public void SetUp()
	{
		taskService = new TaskService();
	}
	//This adds a task to test the system with. It creates a new task service to ensure that
	//this information is able to be accessed. It then adds in the information fed into the
	//test and then checks that the information equals what should be there.
	@Test
	public void AddTaskTest()
	{
		Task task = new Task("1", "First Task", "Task's description");
		
		assertTrue(taskService.AddTask(task));
	}
	
	//This test adds a task and deletes the information when we call upon it to do
	//so with the information found in the task_ID. We then check that the information
	//is no longer there by using that same information.
	@Test
	public void DeleteTaskTest()
	{
		
		Task task = new Task("02", "New Task", "Task description.");
		
		taskService.AddTask(task);
		
		assertTrue(taskService.DeleteTask("02"));
	}
	
	//Verifies that the task created in the delete task test was deleted.
	@Test
	public void VerifyTaskDeleted()
	{
		assertFalse(taskService.DeleteTask("02"));
	}

	
	//First this test creates a new task service and then adds information in. From there
	//the system takes the task_ID we tell it and updates the name's information to the
	//information that we want to change it to. We then have to make sure that the name
	//is what we changed it to.
	@Test
	public void UpdateTaskNameTest()
	{
		Task task = new Task("1", "First Task", "Task's description");
		
		taskService.AddTask(task);
		
		taskService.UpdateTaskName("1", "Task 1");
		
		assertEquals("Task 1", taskService.GetTask("1").GetName());
	}
	
	//This test allows us to make sure that the description update is accurate. With this
	//we have to create a new task first and add it to the list. From there we call on that
	//task_ID and provide the description we wish to change it to. After this, we check that
	//our description matches the updated one.
	public void UpdateTaskDescTest()
	{
		Task task = new Task("1", "First Task", "Task's description");
		
		taskService.AddTask(task);
		
		taskService.UpdateTaskDesc("1", "New Description");
		
		assertEquals("New Description", taskService.GetTask("1").GetDesc());
	}
	
	//Ensures that the test task is retrieved.
	@Test
	public void GetTaskTest()
	{
		Task task = new Task("01", "NewTask", "New Description");

		taskService.AddTask(task);
		
		Task taskRetrieved = taskService.GetTask("01");
		
		assertEquals(task, taskRetrieved);
	}
}
