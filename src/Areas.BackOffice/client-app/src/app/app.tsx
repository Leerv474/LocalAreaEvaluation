import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { AppBase } from "../shared/components/appBase";
import { Layout } from "../shared/components/layout";
import { InfrastructureRouter } from "./infrastructure/router/infrastructureRouter";
import { RegionsRouter} from "./regions/router/regionsRouter";
import { LocalAreasRouter } from "./localAreas/router/localAreasRouter";

export function App() {
  return (
    <AppBase>
      <BrowserRouter>
        <Routes>
          <Route element={<Layout />}>
            {InfrastructureRouter()}
            {LocalAreasRouter()}
            {RegionsRouter()}
          </Route>
        </Routes>
      </BrowserRouter>
    </AppBase>
  );
}
