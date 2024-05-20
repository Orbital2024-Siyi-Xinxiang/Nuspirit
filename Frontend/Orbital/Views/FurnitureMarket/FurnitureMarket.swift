import SwiftUI

struct FurnitureMarketView: View {
  var body: some View {
    ZStack() {
      HStack(spacing: 0) {
        ZStack() {
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 154.94, height: 185)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/155x185"))
            )
            .offset(x: -65.56, y: 0)
          Text("My Assets")
            .font(Font.custom("Press Start 2P", size: 10))
            .foregroundColor(Color(red: 1, green: 0.99, blue: 0.99))
            .offset(x: 19, y: -0.22)
        }
        .frame(width: 286.06, height: 185)
      }
      .padding(EdgeInsets(top: 0, leading: 0, bottom: 4, trailing: 9))
      .offset(x: 419.03, y: 170)
      ZStack() {
        ZStack() {
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 179, height: 38)
            .background(Color(red: 0, green: 0, blue: 0).opacity(0.10))
            .cornerRadius(20)
            .offset(x: 19, y: 0)
          Text("search")
            .font(Font.custom("Press Start 2P", size: 10))
            .foregroundColor(Color(red: 0.23, green: 0.23, blue: 0.23))
            .offset(x: 23.50, y: 4)
          ZStack() {

          }
          .frame(width: 27, height: 26)
          .offset(x: -95, y: -3)
        }
        .frame(width: 217, height: 38)
        .offset(x: 0, y: 0)
        ZStack() {

        }
        .frame(width: 24, height: 24)
        .offset(x: 84.50, y: 0)
      }
      .frame(width: 217, height: 38)
      .offset(x: 298.50, y: -106.50)
      VStack(alignment: .leading, spacing: 1) {
        ZStack() {
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 112, height: 47)
            .background(Color(red: 0.64, green: 0.38, blue: 0.21))
            .cornerRadius(10)
            .offset(x: -54, y: 0)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 112, height: 43.97)
            .background(Color(red: 0.88, green: 0.59, blue: 0.40))
            .cornerRadius(10)
            .offset(x: -56, y: -1.52)
          Text("All")
            .font(Font.custom("Press Start 2P", size: 8))
            .foregroundColor(Color(red: 0.35, green: 0.21, blue: 0.13))
            .offset(x: 13, y: 3)
        }
        .frame(width: 224, height: 47)
        ZStack() {
          ZStack() {
            Rectangle()
              .foregroundColor(.clear)
              .frame(width: 112, height: 47)
              .background(Color(red: 0.64, green: 0.38, blue: 0.21))
              .cornerRadius(10)
              .offset(x: 1, y: 0)
            Rectangle()
              .foregroundColor(.clear)
              .frame(width: 112, height: 43.97)
              .background(Color(red: 0.88, green: 0.59, blue: 0.40))
              .cornerRadius(10)
              .offset(x: -1, y: -1.52)
          }
          .frame(width: 114, height: 47)
          .offset(x: -55, y: 0)
          Text("Housing")
            .font(Font.custom("Press Start 2P", size: 8))
            .foregroundColor(Color(red: 0.35, green: 0.21, blue: 0.13))
            .offset(x: 13, y: 1)
        }
        .frame(width: 224, height: 47)
        ZStack() {
          ZStack() {
            Rectangle()
              .foregroundColor(.clear)
              .frame(width: 112, height: 47)
              .background(Color(red: 0.64, green: 0.38, blue: 0.21))
              .cornerRadius(10)
              .offset(x: 1, y: 0)
            Rectangle()
              .foregroundColor(.clear)
              .frame(width: 112, height: 43.97)
              .background(Color(red: 0.88, green: 0.59, blue: 0.40))
              .cornerRadius(10)
              .offset(x: -1, y: -1.52)
          }
          .frame(width: 114, height: 47)
          .offset(x: -55, y: 0)
          Text("Plants")
            .font(Font.custom("Press Start 2P", size: 8))
            .foregroundColor(Color(red: 0.35, green: 0.21, blue: 0.13))
            .offset(x: 13, y: 4)
        }
        .frame(width: 224, height: 47)
        ZStack() {
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 112, height: 47)
            .background(Color(red: 0.64, green: 0.38, blue: 0.21))
            .cornerRadius(10)
            .offset(x: 1, y: 0)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 112, height: 43.97)
            .background(Color(red: 0.88, green: 0.59, blue: 0.40))
            .cornerRadius(10)
            .offset(x: -1, y: -1.52)
        }
        .frame(width: 114, height: 47)
        ZStack() {
          ZStack() {
            Rectangle()
              .foregroundColor(.clear)
              .frame(width: 112, height: 47)
              .background(Color(red: 0.64, green: 0.38, blue: 0.21))
              .cornerRadius(10)
              .offset(x: 1, y: 0)
            Rectangle()
              .foregroundColor(.clear)
              .frame(width: 112, height: 43.97)
              .background(Color(red: 0.88, green: 0.59, blue: 0.40))
              .cornerRadius(10)
              .offset(x: -1, y: -1.52)
          }
          .frame(width: 114, height: 47)
          .offset(x: -55, y: 0)
          Text("Kitchen")
            .font(Font.custom("Press Start 2P", size: 8))
            .foregroundColor(Color(red: 0.35, green: 0.21, blue: 0.13))
            .offset(x: 13, y: 1)
        }
        .frame(width: 224, height: 47)
        ZStack() {
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 112, height: 47)
            .background(Color(red: 0.64, green: 0.38, blue: 0.21))
            .cornerRadius(10)
            .offset(x: -54, y: 0)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 112, height: 43.97)
            .background(Color(red: 0.88, green: 0.59, blue: 0.40))
            .cornerRadius(10)
            .offset(x: -56, y: -1.52)
          Text("Pets")
            .font(Font.custom("Press Start 2P", size: 8))
            .foregroundColor(Color(red: 0.35, green: 0.21, blue: 0.13))
            .offset(x: 13, y: 1)
        }
        .frame(width: 224, height: 47)
        ZStack() {
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 112, height: 47)
            .background(Color(red: 0.64, green: 0.38, blue: 0.21))
            .cornerRadius(10)
            .offset(x: -54, y: 0)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 112, height: 43.97)
            .background(Color(red: 0.88, green: 0.59, blue: 0.40))
            .cornerRadius(10)
            .offset(x: -56, y: -1.52)
          Text("Avatars")
            .font(Font.custom("Press Start 2P", size: 8))
            .foregroundColor(Color(red: 0.35, green: 0.21, blue: 0.13))
            .offset(x: 13, y: 0)
        }
        .frame(width: 224, height: 47)
        ZStack() {
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 112, height: 47)
            .background(Color(red: 0.64, green: 0.38, blue: 0.21))
            .cornerRadius(10)
            .offset(x: 1, y: 0)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 112, height: 43.97)
            .background(Color(red: 0.88, green: 0.59, blue: 0.40))
            .cornerRadius(10)
            .offset(x: -1, y: -1.52)
        }
        .frame(width: 114, height: 47)
      }
      .padding(EdgeInsets(top: 2, leading: 0, bottom: 0, trailing: 0))
      .background(Color(red: 0.35, green: 0.22, blue: 0.13))
      .offset(x: -373.50, y: 22.50)
      ZStack() {
        Rectangle()
          .foregroundColor(.clear)
          .frame(width: 89, height: 38)
          .background(Color(red: 0.62, green: 0.33, blue: 0.15))
          .cornerRadius(10)
          .offset(x: -5.50, y: 0)
        ZStack() {

        }
        .frame(width: 17, height: 19)
        .offset(x: 20.50, y: 0.50)
        Text("sort")
          .font(Font.custom("Press Start 2P", size: 10))
          .foregroundColor(Color(red: 1, green: 0.99, blue: 0.99))
          .offset(x: 87.03, y: -0.72)
      }
      .frame(width: 100, height: 38)
      .offset(x: 243, y: 169.50)
      ZStack() {
        Group {
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 488, height: 391)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/488x391"))
            )
            .offset(x: 0, y: 42.50)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 100, height: 100)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/100x100"))
            )
            .offset(x: -170, y: -188)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 140, height: 99)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/140x99"))
            )
            .offset(x: 139, y: 31.50)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 148, height: 106)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/148x106"))
            )
            .offset(x: -13, y: 32)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 100, height: 100)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/100x100"))
            )
            .offset(x: -63, y: -183)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 200, height: 200)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/200x200"))
            )
            .offset(x: 32, y: -42)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 61, height: 72)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/61x72"))
            )
            .offset(x: 45.50, y: -178)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 97, height: 132)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/97x132"))
            )
            .offset(x: -177.50, y: -72)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 138, height: 127)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/138x127"))
            )
            .offset(x: -155, y: 21.50)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 133, height: 64)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/133x64"))
            )
            .offset(x: -169.50, y: 97)
        };
          Group {
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 115, height: 149)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/115x149"))
            )
            .offset(x: -32.50, y: 101.50)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 175, height: 158)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/175x158"))
            )
            .offset(x: 57.50, y: 97)
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 73, height: 87)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/73x87"))
            )
            .offset(x: 144.50, y: 101.50)
        }
      }
      .frame(width: 488, height: 476)
      .offset(x: -77, y: 49.50)
      ZStack() {
        ZStack() {
          ZStack() {

          }
          .frame(width: 48, height: 48)
          .offset(x: -2.50, y: 0.50)
          ZStack() {
            Text("1")
              .font(Font.custom("Wendy One", size: 10))
              .foregroundColor(.white)
              .offset(x: 1, y: 0)
          }
          .frame(width: 16, height: 16)
          .offset(x: 18.50, y: -16.50)
        }
        .frame(width: 53, height: 49)
        .offset(x: 390.50, y: -40.50)
        ZStack() {
          ZStack() {
            Rectangle()
              .foregroundColor(.clear)
              .frame(width: 193, height: 232)
              .background(
                AsyncImage(url: URL(string: "https://via.placeholder.com/193x232"))
              )
              .offset(x: 32, y: 0)
            Rectangle()
              .foregroundColor(.clear)
              .frame(width: 247, height: 205.81)
              .background(
                AsyncImage(url: URL(string: "https://via.placeholder.com/247x206"))
              )
              .offset(x: -5, y: -12.16)
          }
          .frame(width: 257, height: 232)
          .offset(x: 0, y: 0)
          Text("0")
            .font(Font.custom("Press Start 2P", size: 15))
            .foregroundColor(Color(red: 1, green: 0.99, blue: 0.99))
            .offset(x: 57, y: 0.47)
        }
        .frame(width: 257, height: 232)
        .offset(x: 243.50, y: -43)
        ZStack() {
          Rectangle()
            .foregroundColor(.clear)
            .frame(width: 119.92, height: 168)
            .background(
              AsyncImage(url: URL(string: "https://via.placeholder.com/120x168"))
            )
            .cornerRadius(10)
            .offset(x: -57.04, y: -64)
          Text("Electrical")
            .font(Font.custom("Press Start 2P", size: 8))
            .foregroundColor(Color(red: 0.35, green: 0.21, blue: 0.13))
            .offset(x: 3, y: 131.50)
          Text("Back")
            .font(Font.custom("Press Start 2P", size: 12))
            .foregroundColor(Color(red: 1, green: 0.99, blue: 0.99))
            .offset(x: 21, y: -64.40)
        }
        .frame(width: 234, height: 296)
        .offset(x: -300, y: 11)
        Rectangle()
          .foregroundColor(.clear)
          .frame(width: 81, height: 91)
          .background(
            AsyncImage(url: URL(string: "https://via.placeholder.com/81x91"))
          )
          .offset(x: 97.50, y: 2.50)
        Rectangle()
          .foregroundColor(.clear)
          .frame(width: 218, height: 173)
          .background(
            AsyncImage(url: URL(string: "https://via.placeholder.com/218x173"))
          )
          .offset(x: 85, y: 95.50)
        Rectangle()
          .foregroundColor(.clear)
          .frame(width: 78, height: 66)
          .background(
            AsyncImage(url: URL(string: "https://via.placeholder.com/78x66"))
          )
          .offset(x: -135, y: 101)
      }
      .frame(width: 834, height: 318)
      .offset(x: -15, y: -121.50)
    }
    .frame(width: 852, height: 393)
    .background(Color(red: 0.98, green: 0.85, blue: 0.79))
    .cornerRadius(20);
  }
}

struct FurnitureMarketView_Previews: PreviewProvider {
  static var previews: some View {
    ContentView()
  }
}
