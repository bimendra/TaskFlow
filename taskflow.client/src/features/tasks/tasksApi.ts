import { apiSlice } from "../api/apiSlice";
import type { CreateTaskRequest, TaskItem, UpdateTaskRequest } from "./interfaces";

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
