import { useEffect, useRef } from "react";

export default function ReceiptCanvas() {
  const canvasRef = useRef<HTMLCanvasElement>(null);

  useEffect(() => {
    const canvas = canvasRef.current;
    if (!canvas) return;

    const ctx = canvas.getContext("2d");
    if (!ctx) return;
    ctx.fillStyle = "#ffffff";
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    drawReceipt(ctx);
  }, []);

  const drawReceipt = (ctx: CanvasRenderingContext2D) => {
    const receiptData = {
      receiptNo: "1234567890",
      owner: "Azik",
      table: "Table 10",
      guestCount: 3,
      opened: "17.07.2023",
      date: "June 29, 2023",
      courier: "Azik",
      items: [
        { name: "Pizza", qty: 2, price: 15.69, total: 31.38 },
        { name: "Coffee", qty: 1, price: 25.79, total: 25.79 },
        { name: "Fries", qty: 1, price: 49.99, total: 49.99 },
        { name: "Ketchup (gift)", qty: 2, price: 0, total: 0 },
      ],
      subtotal: 119.56,
      serviceCharge: 2.5,
      discount: 14.0,
      tax: 10.4,
      delivery: 5.0,
      total: 123.86,
      paymentMethod: { cash: 67.35, card: 56.51 },
    };

    let yPosition = 20;

    ctx.font = "bold 24px 'Courier New', monospace";

    ctx.fillStyle = "#333";
    const title = "Receipt";
    const titleWidth = ctx.measureText(title).width;
    ctx.fillText(title, (canvasRef.current!.width - titleWidth) / 2, yPosition);
    yPosition += 50;

    ctx.font = "16px 'Roboto Mono', monospace";
    ctx.fillStyle = "#333";
    const details = [
      `Receipt No: ${receiptData.receiptNo}`,
      `Owner: ${receiptData.owner}`,
      `Table: ${receiptData.table}`,
      `Guests: ${receiptData.guestCount}`,
      `Opened: ${receiptData.opened}`,
      `Date: ${receiptData.date}`,
      `Courier: ${receiptData.courier}`,
    ];
    details.forEach((detail) => {
      ctx.fillText(detail, 20, yPosition);
      yPosition += 25;
    });

    yPosition += 10;
    ctx.fillStyle = "#ccc";
    ctx.fillRect(20, yPosition, 360, 2);
    yPosition += 30;

    ctx.font = "bold 20px 'Courier New', monospace";
    ctx.fillStyle = "#333";
    ctx.fillText("Products", 20, yPosition);
    yPosition += 25;

    ctx.font = "14px 'Roboto Mono', monospace";
    ctx.fillStyle = "#666";

    receiptData.items.forEach((item) => {
      ctx.fillText(`${item.name}`, 20, yPosition);
      ctx.fillText(`Qty: ${item.qty}`, 200, yPosition);
      ctx.fillText(`$${item.price.toFixed(2)}`, 270, yPosition);
      ctx.fillText(`$${item.total.toFixed(2)}`, 340, yPosition);
      yPosition += 25;
    });

    yPosition += 10;
    ctx.fillStyle = "#ccc";
    ctx.fillRect(20, yPosition, 360, 2);
    yPosition += 30;

    ctx.font = "15px 'Roboto Mono', monospace";
    ctx.fillStyle = "#333";
    ctx.fillText(
      `Subtotal: $${receiptData.subtotal.toFixed(2)}`,
      20,
      yPosition
    );
    yPosition += 25;
    ctx.fillText(
      `Service Charge: $${receiptData.serviceCharge.toFixed(2)}`,
      20,
      yPosition
    );
    yPosition += 25;
    ctx.fillText(
      `Discount: -$${receiptData.discount.toFixed(2)}`,
      20,
      yPosition
    );
    yPosition += 25;
    ctx.fillText(`Tax: $${receiptData.tax.toFixed(2)}`, 20, yPosition);
    yPosition += 25;
    ctx.fillText(
      `Delivery: $${receiptData.delivery.toFixed(2)}`,
      20,
      yPosition
    );

    yPosition += 30;
    ctx.font = "bold 22px 'Roboto Mono', monospace";
    ctx.fillStyle = "#333";
    ctx.fillText(`Total: $${receiptData.total.toFixed(2)}`, 210, yPosition);

    yPosition += 40;
    ctx.font = "14px 'Roboto Mono', monospace";
    ctx.fillStyle = "#666";
    ctx.fillText(
      `Paid by Cash: $${receiptData.paymentMethod.cash.toFixed(2)}`,
      20,
      yPosition
    );
    yPosition += 25;
    ctx.fillText(
      `Paid by Card: $${receiptData.paymentMethod.card.toFixed(2)}`,
      20,
      yPosition
    );
    yPosition += 40;
    ctx.font = "italic 16px 'Roboto Mono', monospace";
    ctx.fillStyle = "#333";
    ctx.fillText("Powered by xx.efi", 120, yPosition);
  };

  return (
    <div
      style={{
        display: "flex",
        justifyContent: "center",
        marginTop: "20px",
        padding: "10px",
        borderRadius: "10px",
        boxShadow: "0 2px 4px rgba(0, 0, 0, 0.2)",
      }}
    >
      <canvas
        ref={canvasRef}
        width={400}
        height={700}
        style={{
          border: "none",
          boxShadow: "0 2px 5px rgba(0, 0, 0, 0.2)",
          padding: "5px",
          backgroundColor: "#fff",
          overflow: "hidden",
        }}
      />
    </div>
  );
}
