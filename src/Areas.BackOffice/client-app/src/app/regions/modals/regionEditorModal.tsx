import React, { useEffect, useState } from "react";
import { Region } from "../../../domain/regions/region";
import { RegionBlank } from "../../../domain/regions/regionBlank";
import { RegionsProvider } from "../../../domain/regions/regionProvider";
import { Button } from "../../../shared/components/buttons/button";
import { Input } from "../../../shared/components/inputs/input";
import { Modal } from "../../../shared/components/modals/modal";
import { Notification } from "../../../shared/components/notification";
import { FederalDistrict } from "../../../domain/regions/enums/federalDistrict";
import { Enum } from "../../../tools/types/enum";

interface Props {
  regionId: string | null;
  onClose: (isEdited: boolean) => void;
  isOpen: boolean;
}

export function RegionEditorModal(props: Props) {
  const [regionBlank, setRegionBlank] = useState<RegionBlank>(
    RegionBlank.getDefault(),
  );
  const [errorMessage, setErrorMessage] = useState<string | null>(null);
  const [plateCodesString, setPlateCodesString] = useState<string>("");

  useEffect(() => {
    if (!props.isOpen) return;

    async function loadRegionBlank() {
      let regionBlank: RegionBlank | null = null;

      if (props.regionId != null) {
        const region: Region | null = await RegionsProvider.getRegionById(
          props.regionId,
        );
        if (region == null) throw "Region is null";

        regionBlank = RegionBlank.fromRegion(region);
      }

      setRegionBlank(regionBlank ?? RegionBlank.getDefault());
      setPlateCodesString(regionBlank?.plateCodes.toString() || "");
    }

    loadRegionBlank();

    return () => {
      setRegionBlank(RegionBlank.getDefault());
      setPlateCodesString(RegionBlank.getDefault().plateCodes.toString());
      setErrorMessage(null);
    };
  }, [props.isOpen, props.regionId]);

  async function saveRegion() {
    regionBlank.plateCodes = plateCodesString
      .split(",")
      .map((s) => s.trim())
      .filter(Boolean);
    const result = await RegionsProvider.saveRegion(regionBlank);
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
          Редактор Региона
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
            variant="text"
            title="Введите название"
            value={regionBlank.name}
            onChange={(name) =>
              setRegionBlank((regionBlank) => ({ ...regionBlank, name }))
            }
            required
          />
          <Input
            variant="select"
            title="Выберите федеральный округ"
            options={Enum.getNumberValues<FederalDistrict>(FederalDistrict)}
            getOptionLabel={(option) => FederalDistrict.getDisplayName(option)}
            isOptionEqualToValue={(a, b) => a === b}
            value={regionBlank.federalDistrict ?? FederalDistrict.Central}
            onChange={(federalDistrict) => {
              setRegionBlank((regionBlank) => ({
                ...regionBlank,
                federalDistrict,
              }));
            }}
            required
          />
          <Input
            variant="text"
            title="Введите автомобильные коды"
            value={plateCodesString}
            onChange={(plateCodes) => setPlateCodesString(plateCodes || "")}
            required
          />
        </Modal.Body>
        <Modal.Footer>
          <Button variant="save" onClick={() => saveRegion()} />
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
