import { createRoot } from "react-dom/client";
import "./index.css";
import "../i18n.ts";
import "rsuite/dist/rsuite.min.css";

import {
  ThemeProvider as MUIThemeProvider,
  createTheme,
} from "@mui/material/styles";
import AppRoutes from "./routes/appRoutes";
import { BrowserRouter } from "react-router-dom";

const muiTheme = createTheme({});

createRoot(document.getElementById("root")!).render(
  <BrowserRouter>
    <MUIThemeProvider theme={muiTheme}>
      <AppRoutes />
    </MUIThemeProvider>
  </BrowserRouter>
);
