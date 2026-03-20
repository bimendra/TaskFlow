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
