import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import App from "./App.tsx";
import { Provider } from "react-redux";
import { store } from "./app/store.ts";
import CssBaseline from "@mui/material/CssBaseline";
import { createBrowserRouter } from "react-router";
import { RouterProvider } from "react-router/dom";

const router = createBrowserRouter([{ path: "/", element: <App /> }]);

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <Provider store={store}>
      <CssBaseline />
      <RouterProvider router={router} />
    </Provider>
  </StrictMode>,
);
