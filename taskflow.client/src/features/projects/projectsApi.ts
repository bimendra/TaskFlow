import { apiSlice } from "../api/apiSlice";

export interface Project {
  id: number;
  name: string;
  description?: string | null;
  status: string;
  createdAtUtc: string;
}

export interface CreateProjectRequest {
  name: string;
  description?: string;
  status: string;
}

export interface UpdateProjectRequest {
  id: number;
  name: string;
  description?: string;
  status: string;
}

export const projectsApi = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getProjects: builder.query<Project[], void>({
      query: () => "/projects",
      providesTags: ["Projects"],
    }),

    getProjectById: builder.query<Project, number>({
      query: (id) => `/projects/${id}`,
      providesTags: (_result, _error, id) => [{ type: "Projects", id }],
    }),

    createProject: builder.mutation<Project, CreateProjectRequest>({
      query: (body) => ({
        url: "/projects",
        method: "POST",
        body,
      }),
      invalidatesTags: ["Projects"],
    }),

    updateProject: builder.mutation<void, UpdateProjectRequest>({
      query: ({ id, ...body }) => ({
        url: `/projects/${id}`,
        method: "PUT",
        body,
      }),
      invalidatesTags: (_result, _error, arg) => ["Projects", { type: "Projects", id: arg.id }],
    }),

    deleteProject: builder.mutation<void, number>({
      query: (id) => ({
        url: `/projects/${id}`,
        method: "DELETE",
      }),
      invalidatesTags: ["Projects"],
    }),
  }),
});

export const {
  useGetProjectsQuery,
  useGetProjectByIdQuery,
  useCreateProjectMutation,
  useUpdateProjectMutation,
  useDeleteProjectMutation,
} = projectsApi;
