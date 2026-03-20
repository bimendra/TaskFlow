import { apiSlice } from "../api/apiSlice";

export interface TaskItem {
  id: number;
  projectId: number;
  title: string;
  description?: string | null;
  status: string;
  priority: string;
  assignedTo?: string | null;
  dueDateUtc?: string | null;
  createdAtUtc: string;
}

export interface CreateTaskRequest {
  projectId: number;
  title: string;
  description?: string;
  status: string;
  priority: string;
  assignedTo?: string;
  dueDateUtc?: string;
}

export interface UpdateTaskRequest {
  id: number;
  title: string;
  description?: string;
  status: string;
  priority: string;
  assignedTo?: string;
  dueDateUtc?: string;
}

export const tasksApi = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getTasksByProject: builder.query<TaskItem[], number>({
      query: (projectId) => `/projects/${projectId}/tasks`,
      providesTags: (_result, _error, projectId) => [{ type: "Tasks", id: projectId }],
    }),

    createTask: builder.mutation<TaskItem, CreateTaskRequest>({
      query: ({ projectId, ...body }) => ({
        url: `/projects/${projectId}/tasks`,
        method: "POST",
        body,
      }),
      invalidatesTags: (_result, _error, arg) => [{ type: "Tasks", id: arg.projectId }],
    }),

    updateTask: builder.mutation<void, UpdateTaskRequest>({
      query: ({ id, ...body }) => ({
        url: `/tasks/${id}`,
        method: "PUT",
        body,
      }),
      invalidatesTags: ["Tasks"],
    }),

    deleteTask: builder.mutation<void, { id: number; projectId: number }>({
      query: ({ id }) => ({
        url: `/tasks/${id}`,
        method: "DELETE",
      }),
      invalidatesTags: (_result, _error, arg) => [{ type: "Tasks", id: arg.projectId }],
    }),
  }),
});

export const {
  useGetTasksByProjectQuery,
  useCreateTaskMutation,
  useUpdateTaskMutation,
  useDeleteTaskMutation,
} = tasksApi;
