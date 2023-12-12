# GitHubの使い方
## 代表の動き
  1. GitHub側で各ブランチからの**PullRequest(以降：プルリク)**を**Merge**する
  2. VSCode側で各ブランチをmainブランチに全**Merge**する

### 動き詳細
<details><summary>GitHub側で各ブランチからの<strong>プルリク</strong>を<strong>Merge</strong>する</summary>
  <ol>
    <li>代表のGitHubに<strong>プルリク</strong>が飛んでくるので、内容が問題なかったらGitHub上で<strong>Merge</strong>する</li>
  </ol>
</details>

<details><summary>VSCode側で各ブランチをmainブランチに全<strong>Merge</strong>する</summary>
  <ol>
    <li>VSCodeのソース管理(Ctrl+Shift+G)のタブを見る</li>
    <li>mainを選択し、HEAD(Origin)がついてない各ブランチをそれぞれ<strong>Merge</strong>する</li>
    <li>全<strong>Merge</strong>したmainブランチをPushする</li>
  </ol>
</details>

## チームメンバー(代表も含む)の動き
  1. 各自のブランチを使用してVSCode側で**Commit/Push**する
  2. GitHub側で自身のブランチを代表の同名ブランチに対して**プルリク**する
  3. (代表がmainを**Merge**した宣告を受けた後)GitHub側でmainブランチを**SyncFork**する
  4. VSCodeのソース管理(Ctrl+Shift+G)の「プル、プッシュ > 全てのリモートからフェッチ」してmainをブランチに**Merge**する

### 動き詳細

<details><summary>各自のブランチを使用してVSCode側で<strong>Commit/Push</strong>する</summary>
  <ol>
    <li>Unity(VSCode)で何らかの編集をおこなう</li>
    <li>VSCodeのソース管理(Ctrl+Shift+G)を開き、変更内容にわかりやすいコメント付けて<strong>Commit/Push</strong>する</li>
  </ol>
</details>

<details><summary>GitHub側で自身のブランチを代表の同名ブランチに対して<strong>プルリク</strong>する</summary>
  <ol>
    <li>VSCodeの<strong>Commit/Push</strong>終了後に自分のGitHubを開く</li>
    <li><strong>プルリク</strong>を開き、<strong>プルリク</strong>する向きと内容を確認して変更内容を記述し、<strong>プルリク</strong>を送付する</li>
    <li><strong>プルリク</strong>時の向きと内容は「<strong>代表GitURL ： mainブランチ ← 自分のGitURL ： 自分のブランチ</strong>」</li>
    <li>内容を全て確認し終えたら、<strong>プルリク</strong>を送付。</li>
    <li>送付後はdiscordで代表に<strong>プルリク</strong>送付報告をする。</li>
  </ol>
</details>

<details><summary>(代表がmainを<strong>Merge</strong>した宣告を受けた後)GitHub側でmainブランチを<strong>SyncFork</strong>する</summary>
  <ol>
    <li>注！）代表からmainブランチを<strong>Merge</strong>した宣言を受けたときに行う</li>
    <li>自分のGitHubを開き、<strong>Merge</strong>されたmainブランチを <strong>SyncFork</strong> する</li>
  </ol>
</details>


<details><summary>VSCodeのソース管理(Ctrl+Shift+G)の「プル、プッシュ > 全てのリモートからフェッチ」して自分のmainブランチでPullしたあと、自分のワークブランチにメインブランチを<strong>Merge</strong>する</summary>
  <ol>
    <li>VSCodeの自分のブランチを開く</li>
    <li>VSCodeのソース管理(Ctrl+Shift+G)の「<strong>Pull, Push</strong> > 全てのリモートから<strong>Fetch</strong>」</li>
    <li><strong>Fetch</strong>内容があれば、<strong>Pull</strong> する(ローカルファイルに最新main情報が上書き)</li>
  </ol>
</details>
