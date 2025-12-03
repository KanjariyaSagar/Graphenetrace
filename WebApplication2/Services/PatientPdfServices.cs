using System;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Services
{
    public class PatientPdfService : IPatientPdfService
    {
        public byte[] CreatePatientReport(PatientRowVM patient)
        {
            // QuestPDF community license
            QuestPDF.Settings.License = LicenseType.Community;

            // ----------- Safe values so PDF never crashes on null ----------
            var name = string.IsNullOrWhiteSpace(patient.PatientName) ? "Unknown patient" : patient.PatientName;
            var ward = string.IsNullOrWhiteSpace(patient.Ward) ? "Not recorded" : patient.Ward;
            var gender = string.IsNullOrWhiteSpace(patient.Gender) ? "Not recorded" : patient.Gender;
            var email = string.IsNullOrWhiteSpace(patient.Email) ? "Not recorded" : patient.Email;
            var phone = string.IsNullOrWhiteSpace(patient.Contact) ? "Not recorded" : patient.Contact;
            var nhsNumber = string.IsNullOrWhiteSpace(patient.NHSNumber) ? "Not recorded" : patient.NHSNumber;

            var ageText = patient.Age == 0 ? "Not recorded" : patient.Age.ToString();
            var lastUploadText = patient.LastUploadAt == default
                ? "No uploads recorded"
                : patient.LastUploadAt.ToString("dd MMM yyyy HH:mm");

            var status = string.IsNullOrWhiteSpace(patient.LastStatus) ? "Not recorded" : patient.LastStatus;
            var risk = string.IsNullOrWhiteSpace(patient.RiskTag) ? "Not assessed" : patient.RiskTag;
            var alerts7 = patient.AlertsLast7Days;
            var framesText = patient.LastFrames == 0 ? "Not recorded" : patient.LastFrames.ToString();

            // ----------- Document definition -------------------------------
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(40);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.Grey.Lighten4);

                    page.DefaultTextStyle(x => x
                        .FontSize(11)
                        .FontColor(Colors.Grey.Darken3));

                    // HEADER
                    page.Header().Element(ComposeHeader);

                    // CONTENT
                    page.Content().Element(content =>
                        ComposeContent(content));

                    // FOOTER
                    page.Footer().Element(ComposeFooter);
                });
            });

            // ----------- Generate PDF as byte[] ----------------------------
            return document.GeneratePdf();

            // ==============================================================
            //  Local helper functions
            // ==============================================================

            void ComposeHeader(IContainer container)
            {
                container
                    .PaddingBottom(10)
                    .Row(row =>
                    {
                        // Left: "logo" and title
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("GrapheneTrace")
                                .FontSize(20)
                                .SemiBold()
                                .FontColor(Colors.Blue.Medium);

                            col.Item().Text("Clinician Patient Report")
                                .FontSize(12)
                                .FontColor(Colors.Grey.Darken2);
                        });

                        // Right: generated date
                        row.ConstantItem(170).Column(col =>
                        {
                            col.Item().AlignRight().Text("Generated")
                                .FontSize(9)
                                .FontColor(Colors.Grey.Darken1);

                            col.Item().AlignRight().Text(DateTime.Now.ToString("dd MMM yyyy HH:mm"))
                                .FontSize(9)
                                .SemiBold()
                                .FontColor(Colors.Grey.Darken3);
                        });
                    });
            }

            void ComposeContent(IContainer container)
            {
                container.PaddingVertical(20).Column(col =>
                {
                    // Top "summary cards"
                    col.Item().Row(row =>
                    {
                        row.RelativeItem().Element(c => SummaryCard(
                            c, "Patient", name, "Ward: " + ward, Colors.Blue.Medium));

                        row.RelativeItem().Element(c => SummaryCard(
                            c, "Status", status, "Risk: " + risk, Colors.Green.Medium));

                        row.RelativeItem().Element(c => SummaryCard(
                            c, "Last Upload", lastUploadText, "Frames: " + framesText, Colors.Orange.Medium));
                    });

                    col.Item().Height(15);

                    // Patient overview section
                    col.Item().Text("Patient Overview")
                        .FontSize(14)
                        .SemiBold()
                        .FontColor(Colors.Grey.Darken4);

                    col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(120);
                            columns.RelativeColumn();
                        });

                        void Row(string label, string value)
                        {
                            table.Cell().Element(CellLabel).Text(label);
                            table.Cell().Element(CellValue).Text(value);

                            static IContainer CellLabel(IContainer container2) =>
                                container2
                                    .PaddingVertical(3)
                                    .PaddingRight(5)
                                    .DefaultTextStyle(x => x
                                        .SemiBold()
                                        .FontColor(Colors.Grey.Darken2));

                            static IContainer CellValue(IContainer container2) =>
                                container2.PaddingVertical(3);
                        }

                        Row("Patient name", name);
                        Row("Age", ageText);
                        Row("Gender", gender);
                        Row("Ward", ward);
                        Row("NHS number", nhsNumber);
                        Row("Email", email);
                        Row("Contact", phone);
                    });

                    col.Item().Height(20);

                    // Monitoring summary section
                    col.Item().Text("Monitoring Summary")
                        .FontSize(14)
                        .SemiBold()
                        .FontColor(Colors.Grey.Darken4);

                    col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(170);
                            columns.RelativeColumn();
                        });

                        void Row(string label, string value)
                        {
                            table.Cell().Element(CellLabel).Text(label);
                            table.Cell().Element(CellValue).Text(value);

                            static IContainer CellLabel(IContainer container2) =>
                                container2
                                    .PaddingVertical(3)
                                    .PaddingRight(5)
                                    .DefaultTextStyle(x => x
                                        .SemiBold()
                                        .FontColor(Colors.Grey.Darken2));

                            static IContainer CellValue(IContainer container2) =>
                                container2.PaddingVertical(3);
                        }

                        Row("Last upload", lastUploadText);
                        Row("Frames in last upload", framesText);
                        Row("Current monitoring status", status);
                        Row("Alerts in last 7 days", alerts7.ToString());
                        Row("Overall risk level", risk);
                    });

                    col.Item().Height(20);

                    // Clinical note paragraph
                    col.Item().Text(text =>
                    {
                        text.Span("Clinical note: ")
                            .SemiBold()
                            .FontColor(Colors.Grey.Darken2)
                            .FontSize(10);

                        text.Span("This automatically generated report summarises recent pressure monitoring for this patient. ")
                            .FontColor(Colors.Grey.Darken2)
                            .FontSize(10);

                        text.Span("Values are for demonstration only and must be interpreted together with the full clinical context.")
                            .Italic()
                            .FontColor(Colors.Grey.Darken2)
                            .FontSize(10);
                    });
                });
            }

            void SummaryCard(IContainer container, string title, string main, string sub, string colorHex)
            {
                container
                    .Padding(10)
                    .Background(Colors.White)
                    .Border(1)
                    .BorderColor(Colors.Grey.Lighten2)
                    .CornerRadius(8)
                    .Column(col =>
                    {
                        col.Item().Text(title)
                            .FontSize(9)
                            .FontColor(Colors.Grey.Darken2);

                        col.Item().Text(main)
                            .FontSize(12)
                            .SemiBold()
                            .FontColor(colorHex);

                        col.Item().Text(sub)
                            .FontSize(9)
                            .FontColor(Colors.Grey.Darken1);
                    });
            }

            void ComposeFooter(IContainer container)
            {
                container
                    .PaddingTop(10)
                    .BorderTop(1)
                    .BorderColor(Colors.Grey.Lighten2)
                    .AlignCenter()
                    .Text(t =>
                    {
                        t.Span("GrapheneTrace - Clinician Dashboard Export  |  ")
                            .FontSize(9)
                            .FontColor(Colors.Grey.Darken1);

                        t.Span(DateTime.Now.ToString("dd MMM yyyy HH:mm"))
                            .FontSize(9)
                            .FontColor(Colors.Grey.Darken1);
                    });
            }
        }
    }
}
