import { Container, Typography, CircularProgress, Alert, Stack, Paper } from "@mui/material";
import { useGetProjectsQuery } from "./features/projects/projectsApi";

function App() {
  const { data, isLoading, isError } = useGetProjectsQuery();

  return (
    <Container maxWidth="md" sx={{ py: 4 }}>
      <Typography variant="h4" gutterBottom>
        TaskFlow
      </Typography>

      {isLoading && <CircularProgress />}

      {isError && <Alert severity="error">Failed to load projects.</Alert>}

      <Stack spacing={2} sx={{ mt: 2 }}>
        {data?.map((project) => (
          <Paper key={project.id} sx={{ p: 2 }}>
            <Typography variant="h6">{project.name}</Typography>
            <Typography variant="body2" color="text.secondary">
              {project.description || "No description"}
            </Typography>
            <Typography variant="caption" display="block" sx={{ mt: 1 }}>
              Status: {project.status}
            </Typography>
          </Paper>
        ))}
      </Stack>
    </Container>
  );
}

export default App;
