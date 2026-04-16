import React, { useEffect, useState } from "react";
import { AreaType } from "../../../domain/localAreas/enums/areaType";
import { LocalAreasProvider } from "../../../domain/localAreas/localAreasProvider";
import { Modal } from "../../../shared/components/modals/modal";
import { Notification } from "../../../shared/components/notification";
import { TextField, Typography } from "@mui/material";
import { LocalAreaDetails } from "../../../domain/localAreas/localAreaDetails";

interface Props {
  localAreaId: string | null;
  onClose: (isEdited: boolean) => void;
  isOpen: boolean;
}

export function LocalAreaEvaluationModal(props: Props) {
  const [localAreaDetails, setLocalAreaDetails] = useState<LocalAreaDetails>();
  const [isValuable, setValuable] = useState(false);
  const [errorMessage, setErrorMessage] = useState<string | null>(null);

  useEffect(() => {
    if (!props.isOpen) return;

    async function loadLocalAreaDetails() {
      if (props.localAreaId != null) {
        const localAreaDetails: LocalAreaDetails | null =
          await LocalAreasProvider.getLocalAreaDetailsById(props.localAreaId);
        if (!localAreaDetails) {
          throw "LocalAreaDetails not found";
        }
        setLocalAreaDetails(localAreaDetails);
      }
    }

    async function evaluateLocalArea() {
      if (props.localAreaId != null) {
        const result: boolean | null =
          await LocalAreasProvider.EvaluateLocalAreaById(props.localAreaId);
        if (!result) {
          throw "Failed to evaluate";
        }
        setValuable(result);
      }
    }

    loadLocalAreaDetails();
    evaluateLocalArea();

    return () => {
      setErrorMessage(null);
    };
  }, [props.isOpen, props.localAreaId]);

  return (
    <>
      <Modal onClose={() => props.onClose(false)} isOpen={props.isOpen}>
        <Modal.Header onClose={() => props.onClose(false)}>
          Данные населенного пункта
        </Modal.Header>
        <Modal.Body
          sx={{
            maxWidth: "800px",
            minWidth: "600px",
            display: "flex",
            flexDirection: "column",
            gap: "12px",
          }}
        >
          <TextField
            label="Тип населенного пункта"
            value={
              localAreaDetails?.areaType
                ? AreaType.getDisplayName(localAreaDetails.areaType)
                : "Не найдено"
            }
          />
          <TextField
            label="Название"
            value={localAreaDetails?.name ?? "Не найдено"}
          />
          <TextField
            label="Численность населения"
            value={localAreaDetails?.population ?? "Не найдено"}
          />
          <TextField
            label="Дату основания"
            value={localAreaDetails?.establishmentDate ?? "Не найдено"}
          />
          <TextField
            label="Средняя стоимость номера в отеле"
            value={localAreaDetails?.averageHotelBill ?? "Не найдено"}
          />
          <TextField
            label="Статус героя"
            value={
              localAreaDetails?.isHeroCity
                ? "Является городом-героем"
                : "Не является городом-героем"
            }
          />
          <TextField
            label="Регион"
            value={localAreaDetails?.regionName ?? "Не найдено"}
          />
        </Modal.Body>
        <Modal.Footer sx={{ justifyContent: "center" }}>
          <Typography color={isValuable ? "green" : "red"}>
            {isValuable
              ? "Представляет историческую ценность"
              : "Не представляет историческую ценность"}
          </Typography>
        </Modal.Footer>
      </Modal>
      {String.isNotNullOrWhitespace(errorMessage) && (
        <Notification
          severity="error"
          message={errorMessage}
          onClose={() => setErrorMessage(null)}
        />
      )}
    </>
  );
}
