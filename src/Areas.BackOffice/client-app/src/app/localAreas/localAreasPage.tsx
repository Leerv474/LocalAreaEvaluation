import {
  Checkbox,
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
import { AreaType } from "../../domain/localAreas/enums/areaType";
import { LocalAreasProvider } from "../../domain/localAreas/localAreasProvider";
import { Button } from "../../shared/components/buttons/button";
import { ConfirmModal } from "../../shared/components/modals/confirmModal";
import { Notification } from "../../shared/components/notification";
import { TablePagination } from "../../shared/components/tablePagination";
import { ConfirmModalState } from "../../shared/types/confirmModalState";
import { Pagination } from "../../tools/types/pagination";
import { LocalAreaEditorModal } from "./modals/localAreaEditorModal";
import { LocalAreaDetails } from "../../domain/localAreas/localAreaDetails";
import { LocalAreaEvaluationModal } from "./modals/localAreaEvaluationModal";

type LocalAreaEditorModalState = {
  localAreaId: string | null;
  isOpen: boolean;
};

type LocalAreaEvaluationModalState = {
  localAreaId: string | null;
  isOpen: boolean;
};

interface RemoveLocalAreaConfirmModalState extends ConfirmModalState {
  localAreaId: string | null;
}

export function LocalAreasPage() {
  const [localAreaDetailsList, setLocalAreaDetailsList] = useState<
    LocalAreaDetails[]
  >([]);
  const [pagination, setPagination] = useState<Pagination>(Pagination.default);

  const [localAreaEditorModalState, setLocalAreaEditorModalState] =
    useState<LocalAreaEditorModalState>({
      localAreaId: null,
      isOpen: false,
    });

  const [localAreaEvaluationModalState, setLocalAreaEvaluationModalState] =
    useState<LocalAreaEvaluationModalState>({
      localAreaId: null,
      isOpen: false,
    });
    
  const [
    removeLocalAreaConfirmModalState,
    setRemoveLocalAreaConfirmModalState,
  ] = useState<RemoveLocalAreaConfirmModalState>({
    localAreaId: null,
    ...ConfirmModalState.getClosed(),
  });

  const [errorMessage, setErrorMessage] = useState<string | null>(null);

  useEffect(() => {
    loadLocalAreasPage({ ...pagination });
  }, []);

  async function loadLocalAreasPage(newPagination: Pagination) {
    const localAreasPage = await LocalAreasProvider.getLocalAreasPage(
      newPagination.page,
      newPagination.countInPage,
    );

    setLocalAreaDetailsList(localAreasPage.values);
    setPagination((pagination) => ({
      ...pagination,
      page: newPagination.page,
      countInPage: newPagination.countInPage,
      totalRows: localAreasPage.totalRows,
    }));
  }

  function changePage(page: number) {
    loadLocalAreasPage({ ...pagination, page });
  }

  function changeCountInPage(countInPage: number) {
    loadLocalAreasPage({ ...pagination, countInPage });
  }

  function openLocalAreaEditorModal(localAreaId?: string) {
    setLocalAreaEditorModalState({
      localAreaId: localAreaId ?? null,
      isOpen: true,
    });
  }

  function openLocalAreaEvaluationModal(localAreaId?: string) {
    setLocalAreaEvaluationModalState({
      localAreaId: localAreaId ?? null,
      isOpen: true,
    });
  }

  function closeLocalAreaEditorModal(isEdited: boolean) {
    if (isEdited) loadLocalAreasPage({ ...pagination, page: 1 });
    setLocalAreaEditorModalState({ localAreaId: null, isOpen: false });
  }

  function closeLocalAreaEvaluationModal(isEdited: boolean) {
    if (isEdited) loadLocalAreasPage({ ...pagination, page: 1 });
    setLocalAreaEvaluationModalState({ localAreaId: null, isOpen: false });
  }

  function openRemoveLocalAreaConfirmModal(
    localAreaId: string,
    localAreaName: string,
  ) {
    setRemoveLocalAreaConfirmModalState({
      localAreaId,
      ...ConfirmModalState.getOpen(
        `Вы действительно хотите удалить продукт "${localAreaName}"`,
      ),
    });
  }

  async function closeRemoveLocalAreaConfirmModal(isConfirmed: boolean) {
    if (isConfirmed) {
      if (removeLocalAreaConfirmModalState.localAreaId == null)
        throw "Cannot remove localArea with LocalAreaId = null";

      const result = await LocalAreasProvider.markLocalAreaAsRemoved(
        removeLocalAreaConfirmModalState.localAreaId,
      );
      if (!result.isSuccess) {
        setErrorMessage(result.errors.map((error) => error.message).join(". "));
        return;
      }

      loadLocalAreasPage({ ...pagination, page: 1 });
    }

    setRemoveLocalAreaConfirmModalState({
      localAreaId: null,
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
        <Typography variant="h6">Населенные пункты</Typography>
        <Button
          variant="add"
          title="Создать"
          onClick={() => openLocalAreaEditorModal()}
        />
      </Paper>
      <Paper elevation={3} sx={{ height: "calc(100% - 52px)" }}>
        <TableContainer sx={{ height: "inherit" }}>
          <Table stickyHeader>
            <TableHead>
              <TableRow>
                <TableCell>Название</TableCell>
                <TableCell>Тип</TableCell>
                <TableCell>Численность населения</TableCell>
                <TableCell>Дата основания</TableCell>
                <TableCell>Средняя стоимость номера в отеле</TableCell>
                <TableCell>Является городом-героем</TableCell>
                <TableCell>Регион</TableCell>
                <TableCell>Управление</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {localAreaDetailsList.length === 0 && (
                <TableRow>
                  <TableCell colSpan={5}>Пусто</TableCell>
                </TableRow>
              )}
              {localAreaDetailsList.map((localArea) => {
                return (
                  <TableRow key={`localArea__${localArea.id}`}>
                    <TableCell width="10%">{localArea.name}</TableCell>
                    <TableCell width="10%">
                      {AreaType.getDisplayName(localArea.areaType)}
                    </TableCell>
                    <TableCell width="10%">
                      {localArea.population ?? "—"}
                    </TableCell>
                    <TableCell width="10%">
                      {localArea.establishmentDate.toString()}
                    </TableCell>
                    <TableCell width="10%">
                      {localArea.averageHotelBill}
                    </TableCell>
                    <TableCell width="10%">
                      {localArea.isHeroCity ? (
                        <Checkbox disabled checked />
                      ) : (
                        <Checkbox disabled />
                      )}
                    </TableCell>
                    <TableCell width="10%">{localArea.regionName}</TableCell>
                    <TableCell width="10%">
                      <Button
                        type="icon"
                        variant="action"
                        title="Оценить"
                        size="small"
                        onClick={() =>
                          openLocalAreaEvaluationModal(localArea.id)
                        }
                      />
                      <Button
                        type="icon"
                        variant="edit"
                        size="small"
                        onClick={() => openLocalAreaEditorModal(localArea.id)}
                      />
                      <Button
                        type="icon"
                        variant="remove"
                        size="small"
                        onClick={() =>
                          openRemoveLocalAreaConfirmModal(
                            localArea.id,
                            localArea.name,
                          )
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
      <LocalAreaEditorModal
        localAreaId={localAreaEditorModalState.localAreaId}
        onClose={closeLocalAreaEditorModal}
        isOpen={localAreaEditorModalState.isOpen}
      />
      <LocalAreaEvaluationModal
        localAreaId={localAreaEvaluationModalState.localAreaId}
        onClose={closeLocalAreaEvaluationModal}
        isOpen={localAreaEvaluationModalState.isOpen}
      />
      <ConfirmModal
        title={removeLocalAreaConfirmModalState.title}
        onClose={(isConfirmed) => closeRemoveLocalAreaConfirmModal(isConfirmed)}
        isOpen={removeLocalAreaConfirmModalState.isOpen}
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
