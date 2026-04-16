import { AppBar, Box, Button, Typography } from "@mui/material";
import React from "react";
import { Outlet, Link as RouterLink } from "react-router-dom";

export function Layout() {
  return (
    <>
      <AppBar position="fixed" sx={{ height: 64 }}>
        <Box
          sx={{
            display: "flex",
            width: "100%",
            height: "100%",
            alignItems: "center",
            gap: 4,
            paddingX: 2,
          }}
        >
          <Box
            sx={{
              width: "fit-content",
              height: "100%",
              display: "flex",
              alignItems: "center",
              gap: 10,
            }}
          >
            <Typography sx={{ fontWeight: "bold" }}>Areas</Typography>
            <Box>
              <Button
                component={RouterLink}
                to="/local_areas"
                variant="contained"
                disableRipple
                disableElevation
              >
                Населенные пункты
              </Button>
              <Button
                component={RouterLink}
                to="/regions"
                variant="contained"
                disableRipple
                disableElevation
              >
                Регионы
              </Button>
            </Box>
          </Box>
        </Box>
      </AppBar>
      <Box
        sx={{
          width: "100%",
          height: "100%",
          paddingTop: 10,
          paddingBottom: 2,
          paddingX: 2,
        }}
      >
        <Outlet />
      </Box>
    </>
  );
}
