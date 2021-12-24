using System;
using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            string message = GetMessageForModel(userId, description);
            if (message != null)
            {
                model.AddAttribute("action_result", message);
                return false;
            }

            return true;
        }

        private string GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);
            try
            {
                int result = _taskService.AddTaskForUser(userId, task);
            }
            catch (IndexOutOfRangeException e)
            {
                return e.Message;
            }
            catch (UserNotFoundException e)
            {
                return e.Message;
            }
            catch (TaskAlreadyExistException e)
            {
                return e.Message;
            }
            return null;
        }
    }
}