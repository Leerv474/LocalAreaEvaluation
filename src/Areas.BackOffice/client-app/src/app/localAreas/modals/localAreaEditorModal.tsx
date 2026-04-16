import React, { useEffect, useState } from "react";
import { AreaType } from "../../../domain/localAreas/enums/areaType";
import { LocalArea } from "../../../domain/localAreas/localArea";
import { LocalAreaBlank } from "../../../domain/localAreas/localAreaBlank";
import { LocalAreasProvider } from "../../../domain/localAreas/localAreasProvider";
import { Button } from "../../../shared/components/buttons/button";
import { Input } from "../../../shared/components/inputs/input";
import { Modal } from "../../../shared/components/modals/modal";
import { Notification } from "../../../shared/components/notification";
import { Enum } from "../../../tools/types/enum";
import { RegionItem } from "../../../domain/regions/regionItem";
import { RegionsProvider } from "../../../domain/regions/regionProvider";

interface Props {
  localAreaId: string | null;
  onClose: (isEdited: boolean) => void;
  isOpen: boolean;
}

export function LocalAreaEditorModal(props: Props) {
  const [localAreaBlank, setLocalAreaBlank] = useState<LocalAreaBlank>(
    LocalAreaBlank.getDefault(),
  );
  const [regionItems, setRegionItems] = useState<RegionItem[]>([]);
  const [errorMessage, setErrorMessage] = useState<string | null>(null);

  useEffect(() => {
    if (!props.isOpen) return;

    async function loadLocalAreaBlank() {
      let localAreaBlank: LocalAreaBlank | null = null;

      if (props.localAreaId != null) {
        const localArea: LocalArea | null =
          await LocalAreasProvider.getLocalAreaById(props.localAreaId);
        if (localArea == null) throw "LocalArea is null";

        localAreaBlank = LocalAreaBlank.fromLocalArea(localArea);
      }

      setLocalAreaBlank(localAreaBlank ?? LocalAreaBlank.getDefault());
    }

    async function loadRegionItems() {
      const regionItems: RegionItem[] | null = await RegionsProvider.getAllRegionItems();
      setRegionItems(regionItems);
    }
    loadLocalAreaBlank();
    loadRegionItems();

    return () => {
      setLocalAreaBlank(LocalAreaBlank.getDefault());
      setErrorMessage(null);
    };
  }, [props.isOpen, props.localAreaId]);

  async function saveLocalArea() {
    const result = await LocalAreasProvider.saveLocalArea(localAreaBlank);
    if (!result.isSuccess) {
      setErrorMessage(result.getErrorString());
      return;
    }

    props.onClose(true);
  }

  return (
    <>
      <Modal onClose={() => props.onClose(false)} isOpen={props.isOpen}>
        <Modal.Header onClose={() => props.onClose(false)}>
          Редактор Населенного пункта
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
          <Input
            variant="select"
            title="Выберите тип населенного пункта"
            options={Enum.getNumberValues<AreaType>(AreaType)}
            getOptionLabel={(option) => AreaType.getDisplayName(option)}
            isOptionEqualToValue={(a, b) => a === b}
            value={localAreaBlank.areaType ?? AreaType.City}
            onChange={(areaType) =>
              setLocalAreaBlank((localAreaBlank) => ({
                ...localAreaBlank,
                areaType,
              }))
            }
            required
          />
          <Input
            variant="text"
            title="Введите название"
            value={localAreaBlank.name}
            onChange={(name) =>
              setLocalAreaBlank((localAreaBlank) => ({
                ...localAreaBlank,
                name,
              }))
            }
            required
          />
          <Input
            variant="number"
            title="Введите численность населения"
            value={localAreaBlank.population}
            onChange={(population) =>
              setLocalAreaBlank((localAreaBlank) => ({
                ...localAreaBlank,
                population,
              }))
            }
            required
          />
          <Input
            variant="date"
            title="Введите дату основания"
            value={localAreaBlank.establishmentDate}
            onChange={(establishmentDate) => {
              setLocalAreaBlank((localAreaBlank) => ({
                ...localAreaBlank,
                establishmentDate,
              }));
            }}
            required
          />
          <Input
            variant="number"
            title="Введите среднюю стоимость номера в отеле"
            value={localAreaBlank.averageHotelBill}
            onChange={(averageHotelBill) =>
              setLocalAreaBlank((localAreaBlank) => ({
                ...localAreaBlank,
                averageHotelBill,
              }))
            }
            isAvailableFractionValue
            required
          />
          <Input
            variant="checkbox"
            title="Является городом-героем"
            value={localAreaBlank.isHeroCity}
            onChange={(isHeroCity) =>
              setLocalAreaBlank((localAreaBlank) => ({
                ...localAreaBlank,
                isHeroCity,
              }))
            }
          />
          <Input
            variant="select"
            title="Выберите регион"
            options={regionItems}
            getOptionLabel={(option) =>
              option?.name ?? "Регионы не найдены"
            }
            isOptionEqualToValue={(a, b) => a === b}
            value={regionItems.find(item => item.id == localAreaBlank.regionId) ?? null}
            onChange={(value) => {
              setLocalAreaBlank((localAreaBlank) => ({
                ... localAreaBlank,
                regionId: value?.id ?? null
              }))
            }}
            required
          />
        </Modal.Body>
        <Modal.Footer>
          <Button variant="save" onClick={() => saveLocalArea()} />
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
