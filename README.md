# Client-Song-Analysis
This project analyzes clients' song listening
---

## Input

The input file is a tab-delimited CSV with the following columns:

| Column     | Description                                    |
|------------|------------------------------------------------|
| PLAY_ID    | Unique 16-byte hexadecimal play identifier     |
| SONG_ID    | ID of the song played                          |
| CLIENT_ID  | ID of the client                               |
| PLAY_TS    | Timestamp when the song was played             |

Example line:
44BB190BC24A3964E053CF0A000AB546 544 3 10/08/2016 13:54:00


> 🔹 Only plays from **10/08/2016** (August 10, 2016) are included in the analysis.

---

## Output

The program outputs a CSV file (`output.csv`) with the **distribution** of distinct play counts:

| DISTINCT_PLAY_COUNT | CLIENT_COUNT |
|---------------------|--------------|
| 2                   | 2            |
| 4                   | 1            |

This means:
- 2 clients listened to 2 distinct songs on 10 Aug 2016
- 1 client listened to 4 distinct songs

---

##  How to Run

> Requires [.NET SDK](https://dotnet.microsoft.com/download) installed.

1. Clone the repo
2. Navigate to the project folder:
   ```bash
   cd ExhibitAApp
3. Place the input file exhibitA-input.csv in the same folder (if not already there)
4.Run the app:
  dotnet run

## File Structure
ExhibitAApp/
├── Program.cs               // Main application logic
├── ExhibitAApp.csproj       // C# project file
├── exhibitA-input.csv       // Input data (tab-delimited)
├── output.csv               // Generated result file
├── README.md                // Project description


