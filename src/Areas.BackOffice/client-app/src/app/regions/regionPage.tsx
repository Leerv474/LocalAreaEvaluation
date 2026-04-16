import {
  Container,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import React, { useEffect, useState } from "react";
import { RegionsProvider } from "../../domain/regions/regionProvider";
import { Button } from "../../shared/components/buttons/button";
import { ConfirmModal } from "../../shared/components/modals/confirmModal";
import { Notification } from "../../shared/components/notification";
import { TablePagination } from "../../shared/components/tablePagination";
import { ConfirmModalState } from "../../shared/types/confirmModalState";
import { Pagination } from "../../tools/types/pagination";
import { RegionEditorModal } from "./modals/regionEditorModal";
import { FederalDistrict } from "../../domain/regions/enums/federalDistrict";
import { RegionDetails } from "../../domain/regions/regionDetails";

type RegionEditorModalState = {
  regionId: string | null;
  isOpen: boolean;
};

interface RemoveRegionConfirmModalState extends ConfirmModalState {
  regionId: string | null;
}

export function RegionsPage() {
  const [regions, setRegions] = useState<RegionDetails[]>([]);
  const [pagination, setPagination] = useState<Pagination>(Pagination.default);

  const [regionEditorModalState, setRegionEditorModalState] =
    useState<RegionEditorModalState>({
      regionId: null,
      isOpen: false,
    });
  const [removeRegionConfirmModalState, setRemoveRegionConfirmModalState] =
    useState<RemoveRegionConfirmModalState>({
      regionId: null,
      ...ConfirmModalState.getClosed(),
    });

  const [errorMessage, setErrorMessage] = useState<string | null>(null);

  useEffect(() => {
    loadRegionsPage({ ...pagination });
  }, []);

  async function loadRegionsPage(newPagination: Pagination) {
    const regionsPage = await RegionsProvider.getRegionsPage(
      newPagination.page,
      newPagination.countInPage,
    );

    setRegions(regionsPage.values);
    setPagination((pagination) => ({
      ...pagination,
      page: newPagination.page,
      countInPage: newPagination.countInPage,
      totalRows: regionsPage.totalRows,
    }));
  }

  function changePage(page: number) {
    loadRegionsPage({ ...pagination, page });
  }

  function changeCountInPage(countInPage: number) {
    loadRegionsPage({ ...pagination, countInPage });
  }

  function openRegionEditorModal(regionId?: string) {
    setRegionEditorModalState({
      regionId: regionId ?? null,
      isOpen: true,
    });
  }

  function closeRegionEditorModal(isEdited: boolean) {
    if (isEdited) loadRegionsPage({ ...pagination, page: 1 });
    setRegionEditorModalState({ regionId: null, isOpen: false });
  }

  function openRemoveRegionConfirmModal(regionId: string, regionName: string) {
    setRemoveRegionConfirmModalState({
      regionId,
      ...ConfirmModalState.getOpen(
        `Вы действительно хотите удалить продукт "${regionName}"`,
      ),
    });
  }

  async function closeRemoveRegionConfirmModal(isConfirmed: boolean) {
    if (isConfirmed) {
      if (removeRegionConfirmModalState.regionId == null)
        throw "Cannot remove region with RegionId = null";

      const result = await RegionsProvider.markRegionAsRemoved(
        removeRegionConfirmModalState.regionId,
      );
      if (!result.isSuccess) {
        setErrorMessage(result.errors.map((error) => error.message).join(". "));
        return;
      }

      loadRegionsPage({ ...pagination, page: 1 });
    }

    setRemoveRegionConfirmModalState({
      regionId: null,
      ...ConfirmModalState.getClosed(),
    });
  }

  return (
    <Container
      sx={{
        height: "100%",
        display: "flex",
        flexDirection: "column",
        gap: "12px",
      }}
      maxWidth={false}
      disableGutters
    >
      <Paper
        elevation={3}
        sx={{
          display: "flex",
          alignItems: "center",
          justifyContent: "space-between",
          paddingX: "12px",
          paddingY: "6px",
        }}
      >
        <Typography variant="h6">Регионы</Typography>
        <Button
          variant="add"
          title="Создать"
          onClick={() => openRegionEditorModal()}
        />
      </Paper>
      <Paper elevation={3} sx={{ height: "calc(100% - 52px)" }}>
        <TableContainer sx={{ height: "inherit" }}>
          <Table stickyHeader>
            <TableHead>
              <TableRow>
                <TableCell>Название</TableCell>
                <TableCell>Федеральный округ</TableCell>
                <TableCell>Автомобильные коды</TableCell>
                <TableCell>Количество населенных пунктов</TableCell>
                <TableCell>Управление</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {regions.length === 0 && (
                <TableRow>
                  <TableCell colSpan={5}>Пусто</TableCell>
                </TableRow>
              )}
              {regions.map((region) => {
                return (
                  <TableRow key={`region__${region.id}`}>
                    <TableCell width="25%">{region.name}</TableCell>
                    <TableCell width="25%">
                      {FederalDistrict.getDisplayName(region.federalDistrict)}
                    </TableCell>
                    <TableCell width="25%">
                      {region.plateCodes.toString()}
                    </TableCell>
                    <TableCell width="25%">
                      {region.localityCount.toString()}
                    </TableCell>
                    <TableCell width="25%">
                      <Button
                        type="icon"
                        variant="edit"
                        size="small"
                        onClick={() => openRegionEditorModal(region.id)}
                      />
                      <Button
                        type="icon"
                        variant="remove"
                        size="small"
                        onClick={() =>
                          openRemoveRegionConfirmModal(region.id, region.name)
                        }
                      />
                    </TableCell>
                  </TableRow>
                );
              })}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          countInPageOptions={Pagination.getPageSizeOptions()}
          page={pagination.page}
          countInPage={pagination.countInPage}
          totalRows={pagination.totalRows}
          changePage={(page) => changePage(page)}
          changeCountInPage={(countInPage) => changeCountInPage(countInPage)}
        />
      </Paper>
      <RegionEditorModal
        regionId={regionEditorModalState.regionId}
        onClose={closeRegionEditorModal}
        isOpen={regionEditorModalState.isOpen}
      />
      <ConfirmModal
        title={removeRegionConfirmModalState.title}
        onClose={(isConfirmed) => closeRemoveRegionConfirmModal(isConfirmed)}
        isOpen={removeRegionConfirmModalState.isOpen}
      />
      {String.isNotNullOrWhitespace(errorMessage) && (
        <Notification
          severity="error"
          message={errorMessage}
          onClose={() => setErrorMessage(null)}
        />
      )}
    </Container>
  );
}
