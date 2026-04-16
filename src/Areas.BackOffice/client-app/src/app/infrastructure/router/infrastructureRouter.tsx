import React from "react";
import { Route } from "react-router-dom";
import { InfrastructureLink } from "./infrastructureLink";
import { LocalAreasPage } from "../../localAreas/localAreasPage";

export function InfrastructureRouter() {
  return (
    <>
      <Route path={InfrastructureLink.index} element={<LocalAreasPage />} />
    </>
  );
}
