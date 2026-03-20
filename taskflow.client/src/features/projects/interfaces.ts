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
