import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://localhost:7196/api",
  }),
  tagTypes: ["Projects", "Tasks"],
  endpoints: () => ({}),
});
