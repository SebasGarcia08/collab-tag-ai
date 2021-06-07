export default class Utils {
  public static async getAsByteArray(file: File): Promise<Uint8Array> {
    return new Uint8Array(await this.readImageFile(file));
  }

  private static readImageFile(file: File): Promise<ArrayBuffer> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();

      reader.addEventListener("loadend", (e: any) => resolve(e.target.result));
      reader.addEventListener("error", reject);

      reader.readAsArrayBuffer(file);
    });
  }

  public static async readAsByteArray(file: File): Promise<Uint8Array> {
    const res: ArrayBuffer = await file.arrayBuffer();
    const img = new Uint8Array(res);
    return img;
  }

  public static readAsDataUrl(file: File): Promise<any> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();

      reader.addEventListener("loadend", (e: any) => resolve(e.target.result));
      reader.addEventListener("error", reject);

      reader.readAsDataURL(file);
    });
  }
}
