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

  public static convert2Base64Array(file: File): Promise<Blob> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();

      reader.addEventListener("loadend", (e: any) => resolve(e.target.result));
      reader.addEventListener("error", reject);

      reader.readAsDataURL(file);
    });
  }

  public static base64ToUint8Array(base64: string): Uint8Array {
    const binaryString = window.atob(base64);
    const len = binaryString.length;
    const bytes = new Uint8Array(len);
    for (let i = 0; i < len; i++) {
      bytes[i] = binaryString.charCodeAt(i);
    }
    return bytes;
  }
}
